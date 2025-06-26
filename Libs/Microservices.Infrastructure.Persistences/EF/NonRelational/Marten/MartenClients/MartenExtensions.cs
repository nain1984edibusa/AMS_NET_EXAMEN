using ImTools;
using JasperFx;
using Marten;
using Marten.Linq.Members;
using Marten.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Npgsql;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Weasel.Core;
using static Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients.MartenExtensions;

namespace Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients
{
    public interface IMartenDocumentOptions { }
    public static class MartenExtensions
    {
        public class MartenStoreOptions
        {
            public MartenDatabaseOptions Database { get; set; } = new MartenDatabaseOptions();
            public Dictionary<Type, IMartenDocumentOptions> Documents { get; set; } = new Dictionary<Type, IMartenDocumentOptions>();
        }
        public class MartenDocumentOptions<TEntity> : IMartenDocumentOptions
           where TEntity : class
        {
            public Expression<Func<TEntity, object>> PropertyExpression { get; set; }
            public string SqlType { get; set; } = "varchar(50)";
            public bool IsUnique { get; set; } = true;
        }
        public class MartenDatabaseOptions
        {
            public string ConnectionString { get; set; }
            public string SchemaName { get; set; }
            public bool AutoCreateSchema { get; set; } = true;
        }

        public static IServiceCollection AddMartenDocumentStore(
            this IServiceCollection services,
            Action<MartenStoreOptions> configure
        )
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var options = new MartenStoreOptions();
            configure(options);

            var dbOpts = options.Database;
            services.AddSingleton(options.Database);

            var documentStore = DocumentStore.For(opt =>
            {
                opt.Connection(dbOpts.ConnectionString);
                opt.DatabaseSchemaName = dbOpts.SchemaName;
                opt.Serializer(CustomizeNewtonSoftJsonSerializer());
                opt.AutoCreateSchemaObjects = dbOpts.AutoCreateSchema ? AutoCreate.All : AutoCreate.None;

                foreach (var entry in options.Documents)
                {
                    CreateDocument(entry, opt);
                }
            });

            services.AddSingleton<IDocumentStore>(documentStore);
            services.AddScoped<IDocumentSession>(sp => documentStore.LightweightSession());

            return services;
        }
        private static ISerializer CustomizeNewtonSoftJsonSerializer()
        {
            var serializer = new JsonNetSerializer
            {
                CollectionStorage = CollectionStorage.AsArray,
                EnumStorage = EnumStorage.AsString,
                Casing = Casing.CamelCase
            };

            serializer.Configure(s =>
            {
                s.ContractResolver = new ProtectedSettersContractResolver();
                s.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //s.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            });

            return serializer;
        }   

        private static ISerializer CustomizeJsonSerializer()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReferenceHandler = ReferenceHandler.IgnoreCycles                
            };

            var serializer = new SystemTextJsonSerializer(options)
            {
                EnumStorage = EnumStorage.AsString,
                Casing = Casing.CamelCase
            };

            return serializer;
        }

        public static class MartenDocumentOptionsBuilder
        {
            public static Dictionary<Type, IMartenDocumentOptions> Create(params IMartenDocumentOptions[] options)
            {
                var dict = new Dictionary<Type, IMartenDocumentOptions>();
                foreach (var opt in options)
                {
                    var entityType = opt.GetType().GetGenericArguments()[0];
                    dict[entityType] = opt;
                }
                return dict;
            }
        }

        private static void CreateDocument(KeyValuePair<Type, IMartenDocumentOptions> entry, StoreOptions opt)
        {
            var entityType = entry.Key;
            var docOptions = entry.Value;

            var mapping = GetMapping(entityType, opt);
            var propertyExpression = GetPropertyExpression(docOptions);
            var sqlType = GetSqlType(docOptions);
            var isUnique = GetIsUnique(docOptions);

            ApplyDuplicate(mapping, propertyExpression, sqlType);

            if (isUnique)
                ApplyUniqueIndex(mapping, propertyExpression);
            else
                ApplyIndex(mapping, propertyExpression);
        }

        private static void ApplyDuplicate(object mapping, object propertyExpression, string sqlType)
        {
            var duplicateMethod = mapping.GetType().GetMethod("Duplicate");

            duplicateMethod.Invoke(mapping, new object[] { propertyExpression, sqlType, null, null, false });
        }
        private static void ApplyUniqueIndex(object mapping, object propertyExpression)
        {
            var uniqueIndexMethod = mapping.GetType()
                .GetMethods()
                .First(m =>
                    m.Name == "UniqueIndex"
                    && m.GetParameters().Length == 1
                    && m.GetParameters()[0].ParameterType.IsArray
                    && m.GetParameters()[0].ParameterType.GetElementType().Name.StartsWith("Expression")
                );

            var exprType = propertyExpression.GetType();
            var exprArray = Array.CreateInstance(exprType, 1);
            exprArray.SetValue(propertyExpression, 0);

            uniqueIndexMethod.Invoke(mapping, new object[] { exprArray });
        }
        private static void ApplyIndex(object mapping, object propertyExpression)
        {
            var indexMethod = mapping.GetType()
                 .GetMethods()
                 .First(m =>
                     m.Name == "Index"
                     && m.GetParameters().Length == 2
                     && (m.GetParameters()[0].ParameterType.IsArray ||
                         (m.GetParameters()[0].ParameterType.IsGenericType &&
                          m.GetParameters()[0].ParameterType.GetGenericTypeDefinition().Name.StartsWith("IReadOnlyCollection")))
                     && m.GetParameters()[1].ParameterType.Name == "Action`1"
                 );

            var exprType = propertyExpression.GetType();
            var exprArray = Array.CreateInstance(exprType, 1);
            exprArray.SetValue(propertyExpression, 0);

            indexMethod.Invoke(mapping, new object[] { exprArray });
        }
        private static object GetMapping(Type entityType, StoreOptions opt)
        {
            var schemaForMethod = opt.Schema.GetType().GetMethod("For").MakeGenericMethod(entityType);
            var mapping = schemaForMethod.Invoke(opt.Schema, null);

            return mapping;
        }
        private static object GetPropertyExpression(IMartenDocumentOptions docOptions)
        {
            var propertyExpressionProp = docOptions.GetType().GetProperty("PropertyExpression");
            var propertyExpression = propertyExpressionProp.GetValue(docOptions);

            return propertyExpression;
        }
        private static string GetSqlType(IMartenDocumentOptions docOptions)
        {
            var sqlTypeProp = docOptions.GetType().GetProperty("SqlType");
            var sqlType = sqlTypeProp.GetValue(docOptions) as string;

            return sqlType;
        }
        private static bool GetIsUnique(IMartenDocumentOptions docOptions)
        {
            var isUniqueProp = docOptions.GetType().GetProperty("IsUnique");
            var isUnique = (bool)isUniqueProp.GetValue(docOptions);

            return isUnique;
        }
    }
}
