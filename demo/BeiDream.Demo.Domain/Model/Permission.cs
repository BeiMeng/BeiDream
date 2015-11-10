using BeiDream.Core.Domain.Entities;

namespace BeiDream.Demo.Domain.Model
{
    public class Permission : Entity
    {
        public virtual PermissionValue Value
        {
            get;
            set;
        }

        public virtual Privilege Privilege
        {
            get;
            set;
        }
    }
}