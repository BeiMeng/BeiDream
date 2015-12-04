using System.ComponentModel;

namespace BeiDream.Demo.Domain.Enums {
    /// <summary>
    /// 资源类型
    /// </summary>
    public enum ResourceType {
        /// <summary>
        /// 模块
        /// </summary>
        [Description("模块")]
        Module = 0,
        /// <summary>
        /// 菜单
        /// </summary>
        [Description( "菜单" )]
        Menu = 1,
        /// <summary>
        /// 操作(按钮)
        /// </summary>
        [Description( "操作(按钮)" )]
        Operation = 2,
        /// <summary>
        /// 字段(列)
        /// </summary>
        [Description( "字段(列)" )]
        Field = 3,
        /// <summary>
        /// 记录(行)
        /// </summary>
        [Description( "记录(行)" )]
        Record = 4
    }
}
