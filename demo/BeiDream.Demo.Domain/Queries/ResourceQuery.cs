using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Domain.Queries
{
    public class ResourceQuery : Pager
    {
        public string Name { get; set; }
        public bool? Enabled { get; set; }
    }
}