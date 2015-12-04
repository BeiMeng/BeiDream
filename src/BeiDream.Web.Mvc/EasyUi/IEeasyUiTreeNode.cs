using System.Collections.Generic;

namespace BeiDream.Web.Mvc.EasyUi
{
    public interface IEeasyUiTreeNode : ITreeNode
    {
        object attributes { get; set; }
        bool? @checked { get; set; }
        string iconClass { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        string state { get; set; }
        /// <summary>
        /// 子节点集合
        /// </summary>
        List<IEeasyUiTreeNode> children { get; set; }
    }
}