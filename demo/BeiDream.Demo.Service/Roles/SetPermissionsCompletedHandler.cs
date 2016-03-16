using System;
using BeiDream.Core.Dependency;
using BeiDream.Core.Events.Bus.Handlers;

namespace BeiDream.Demo.Service.Roles
{
    /// <summary>
    /// 角色设置权限完成之后触发的处理事件(清除当前角色缓存的权限列表)
    /// </summary>
    public class SetPermissionsCompletedHandler : IEventHandler<SetPermissionsCompletedEventData>, ITransientDependency 
    {
        public void HandleEvent(SetPermissionsCompletedEventData eventData)
        {
            Guid aa = eventData.RoleId;
        }
    }
}