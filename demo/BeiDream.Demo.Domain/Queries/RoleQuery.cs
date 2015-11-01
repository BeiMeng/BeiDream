using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Domain.Queries
{
    public class RoleQuery : Pager
    {
        public string Name { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? Enabled { get; set; }
    }
}