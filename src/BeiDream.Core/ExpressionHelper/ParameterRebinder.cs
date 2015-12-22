using System.Collections.Generic;
using System.Linq.Expressions;

namespace BeiDream.Core.ExpressionHelper {
    /// <summary>
    /// 参数重绑定操作
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor {
        /// <summary>
        /// 参数字典
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

        /// <summary>
        /// 初始化参数重绑定操作
        /// </summary>
        /// <param name="map">参数字典</param>
        public ParameterRebinder( Dictionary<ParameterExpression, ParameterExpression> map ) {
            _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// 替换参数
        /// </summary>
        /// <param name="map">参数字典</param>
        /// <param name="exp">表达式</param>
        public static System.Linq.Expressions.Expression ReplaceParameters( Dictionary<ParameterExpression, ParameterExpression> map, System.Linq.Expressions.Expression exp ) {
            return new ParameterRebinder( map ).Visit( exp );
        }

        /// <summary>
        /// 访问参数
        /// </summary>
        /// <param name="parameterExpression">参数</param>
        protected override System.Linq.Expressions.Expression VisitParameter( ParameterExpression parameterExpression ) {
            ParameterExpression replacement;
            if( _map.TryGetValue( parameterExpression, out replacement ) )
                parameterExpression = replacement;
            return base.VisitParameter( parameterExpression );
        }
    }
}
