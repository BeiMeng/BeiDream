using System;

namespace BeiDream.Core.Domain.Uow.Interception
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NoUnitOfWorkAttribute : Attribute
    {
         
    }
}