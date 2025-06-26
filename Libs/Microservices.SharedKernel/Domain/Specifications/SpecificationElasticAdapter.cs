using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.SharedKernel.Domain.Specifications
{
    public static class SpecificationElasticAdapter
    {
        public static Query ToElasticQuery<T>(this ISpecification<T> specification)
        {
            // Only for equality (expr == value)
            var expr = specification.Criteria.Body as BinaryExpression;
            if (expr == null) throw new NotSupportedException("Only simple binary expressions are supported");

            if (expr.NodeType == ExpressionType.Equal)
            {
                var memberExpr = expr.Left as MemberExpression;
                var constantExpr = expr.Right as ConstantExpression;
                if (memberExpr != null && constantExpr != null)
                {
                    var fieldName = memberExpr.Member.Name;
                    var value = constantExpr.Value;

                    // Safe "cast" here:
                    FieldValue fieldValue = value switch
                    {
                        string s => s,
                        int i => i,
                        long l => l,
                        bool b => b,
                        DateTime dt => dt.ToString("o"),
                        DateTimeOffset dto => dto.ToString("o"),
                        Guid g => g.ToString(),
                        decimal d => (double)d,
                        double db => db,
                        float f => f,
                        _ => throw new NotSupportedException("Value type not supported for TermQuery: " + value?.GetType().Name)
                    };

                    
                    return new TermQuery()
                    {
                        Field = fieldName,
                        Value = fieldValue
                    };
                }
            }
            throw new NotSupportedException("Only simple == expressions are supported");
        }
    }
}