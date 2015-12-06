using System.Collections.Generic;

namespace BeiDream.Web.Mvc.EasyUi.Tree
{
    public class EeasyUiTreeNode : IEeasyUiTreeNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string Path { get; set; }
        public int Level { get; set; }
        public int SortId { get; set; }

        public string id
        {
            get { return Id; }
        }

        public string text
        {
            get { return Name; }
        }

        public object attributes { get; set; }
        public bool? @checked { get; set; }
        public string iconClass { get; set; }
        public string state { get; set; }
        public List<IEeasyUiTreeNode> children { get; set; }
    }
}