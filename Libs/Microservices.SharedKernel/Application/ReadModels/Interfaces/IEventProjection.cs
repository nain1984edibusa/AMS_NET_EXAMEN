using Microservices.SharedKernel.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.SharedKernel.Application.ReadModels.Interfaces
{
    public interface IEventProjection<TEvent, TEvenResult> : IProjection<TEvent, TEvenResult> 
        where TEvent : IEvent
        where TEvenResult : IResult
    { }
    public interface IEventProjection<TEvent> : IProjection<TEvent> 
        where TEvent : IEvent
    { }
}
