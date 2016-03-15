using System;
using BeiDream.Core.Dependency;
using BeiDream.Core.Events.Bus.Handlers;

namespace BeiDream.Demo.Service.Impl
{
    public class SetPermissionsCompletedHandler : IEventHandler<SetPermissionsCompletedEventData>, ITransientDependency 
    {
        public void HandleEvent(SetPermissionsCompletedEventData eventData)
        {
            Guid aa = eventData.RoleId;
        }
    }
}