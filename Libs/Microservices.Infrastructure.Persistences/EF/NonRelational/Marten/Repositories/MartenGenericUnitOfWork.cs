using Marten;
using Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using Npgsql;
using static Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients.MartenExtensions;

namespace Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.Repositories
{
    public class MartenGenericUnitOfWork<TDocumentSession> : IGenericUnitOfWork 
        where TDocumentSession: IDocumentSession        
    {
        private readonly IDocumentStore _documentStore;
        private readonly IDocumentSession _session;
        private readonly MartenDatabaseOptions _dbOptions;

        public MartenGenericUnitOfWork(
            IDocumentStore documentStore,
            IDocumentSession session,
            MartenDatabaseOptions dbOptions
        )
        {
            _documentStore = documentStore;
            _session = session;
            _dbOptions = dbOptions;
        }

        public async Task EnsureCreatedAsync(CancellationToken cancellationToken = default)
        {           
            var builder = new NpgsqlConnectionStringBuilder(_dbOptions.ConnectionString);
            var dbName = builder.Database;

            builder.Database = "postgres";

            using (var conn = new NpgsqlConnection(builder.ToString()))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT 1 FROM pg_database WHERE datname = '{dbName}'";
                    var exists = cmd.ExecuteScalar() != null;
                    if (!exists)
                    {
                        cmd.CommandText = $"CREATE DATABASE \"{dbName}\"";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public async Task MigrateAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException("Marten does not require explicit migrations like EF Core. It uses schema generation on the fly.");
        }

        public async Task<int> CompleteAsync()
        {
            await _session.SaveChangesAsync();
            return 1;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _session.Dispose();
        }

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task RollbackTransactionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
