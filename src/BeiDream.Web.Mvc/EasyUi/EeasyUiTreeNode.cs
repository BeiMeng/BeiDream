using System.Collections.Generic;

namespace BeiDream.Web.Mvc.EasyUi
{
    public class EeasyUiTreeNode : IEeasyUiTreeNode
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Path { get; set; }
        public int Level { get; set; }
        public int SortId { get; set; }
        public object attributes { get; set; }
        public bool? @checked { get; set; }
        public string iconClass { get; set; }
        public string state { get; set; }
        public List<IEeasyUiTreeNode> children { get; set; }
    }
}