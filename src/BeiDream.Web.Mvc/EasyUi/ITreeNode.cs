﻿using System.Collections.Generic;

namespace BeiDream.Web.Mvc.EasyUi {
    /// <summary>
    /// 树节点
    /// </summary>
    public interface ITreeNode {
        /// <summary>
        /// 标识
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// 父标识
        /// </summary>
        string ParentId { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        int Level { get; set; }
        /// <summary>
        /// 同级排序号
        /// </summary>
        int SortId { get; set; }
    }
}
