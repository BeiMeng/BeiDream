using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;

namespace BeiDream.Web.Mvc.EasyUi.Tree
{
    /// <summary>
    /// easyui树形结构数据生成工具
    /// </summary>
    public class EasyUiTreeData
    {
        /// <summary>
        /// 初始化树结果
        /// </summary>
        /// <param name="nodes">树节点集合</param>
        /// <param name="isAyncLoad">是否异步加载</param>
        public EasyUiTreeData(IEnumerable<IEeasyUiTreeNode> nodes, bool isAyncLoad = false)
        {
            _nodes = nodes;
            _isAsyncLoad = isAyncLoad;
        }

        /// <summary>
        /// 树节点集合
        /// </summary>
        private readonly IEnumerable<IEeasyUiTreeNode> _nodes;
        /// <summary>
        /// 是否异步加载
        /// </summary>
        private readonly bool _isAsyncLoad;

        /// <summary>
        /// 获取节点
        /// </summary>
        public List<IEeasyUiTreeNode> GetNodes()
        {
            var result = new List<IEeasyUiTreeNode>();
            if (_nodes == null)
                return result;
            foreach (var root in _nodes.Where(IsRoot).OrderBy(p=>p.SortId))
                AddNode(result, root);
            return result;
        }

        /// <summary>
        /// 是否根节点
        /// </summary>
        private bool IsRoot(IEeasyUiTreeNode node)
        {
            if (_nodes.Any(t => t.ParentId.IsEmpty()))
                return node.ParentId.IsEmpty();
            return node.Level == _nodes.Min(t => t.Level);
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        private void AddNode(List<IEeasyUiTreeNode> result, IEeasyUiTreeNode node)
        {
            if (node == null)
                return;
            if (IsRoot(node))
                result.Add(node);
            if (IsLeaf(node))
            {
                SetState(node);
                return;
            }
            SetNoChecked(node);
            node.children = GetChilds(node);
            foreach (var child in node.children)
                AddNode(result, child);
        }

        /// <summary>
        /// 是否叶节点
        /// </summary>
        private bool IsLeaf(IEeasyUiTreeNode node)
        {
            return _nodes.All(t => t.ParentId != node.Id);
        }

        /// <summary>
        /// 设置叶节点状态
        /// </summary>
        private void SetState(IEeasyUiTreeNode leaf)
        {
            if (_isAsyncLoad)
                leaf.state = TreeNodeState.closed.ToString();
        }
        /// <summary>
        /// 设置非叶节点不选中，会自动关联选中
        /// </summary>
        private void SetNoChecked(IEeasyUiTreeNode leaf)
        {
                leaf.@checked = false;
        }
        /// <summary>
        /// 获取节点直接下级
        /// </summary>
        private List<IEeasyUiTreeNode> GetChilds(IEeasyUiTreeNode node)
        {
            return _nodes.Where(t => t.ParentId == node.Id).OrderBy(p=>p.SortId).ToList();
        }
    }
}