using Microservices.SharedKernel.Application.ReadModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.SharedKernel.Domain.Entities
{
    public abstract class ReadModel<TId> : IReadModel
    {
        public TId Id { get; protected set; }

        protected ReadModel()
        {
            Id = default!;
        }

        protected ReadModel(TId id)
        {
            Id = id;
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other)
                return false;

            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode() => Id!.GetHashCode();
    }
}
