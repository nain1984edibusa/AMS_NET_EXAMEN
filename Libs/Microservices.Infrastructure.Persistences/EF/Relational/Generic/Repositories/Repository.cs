using Microservices.SharedKernel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Persistences.EF.Relational.Generic
{
    public class Repository<T, TDbContext>
        : GenericRepository<T, TDbContext>, IRepository<T>
        where T : class, IAggregateRoot
        where TDbContext : DbContext
    {
        public Repository(TDbContext context) : base(context) { }
    }
}
