using System.ComponentModel;

namespace BeiDream.Web.Mvc.EasyUi.Tree {
    /// <summary>
    /// 树节点状态
    /// </summary>
    public enum TreeNodeState {
        /// <summary>
        /// 展开
        /// </summary>
        [Description( "open" )]
        open,
        /// <summary>
        /// 关闭
        /// </summary>
        [Description( "closed" )]
        closed
    }
}
