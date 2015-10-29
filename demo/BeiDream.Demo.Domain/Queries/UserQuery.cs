using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Domain.Queries
{
    public class UserQuery:Pager
    {
        public string Name { get; set; }
        public bool? Enable { get; set; }
    }
}