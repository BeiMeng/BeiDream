using System;
using System.Linq;
using System.Linq.Expressions;

namespace BeiDream.Core.ExpressionHelper.Extensions
{
    /// <summary>
    /// 表达式扩展类
    /// </summary>
    public static class ExpressionExtensins
    {
        #region Compose(组合表达式)

        /// <summary>
        /// 组合表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="first">左操作数</param>
        /// <param name="second">右操作数</param>
        /// <param name="merge">合并操作</param>
        internal static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second,
            Func<System.Linq.Expressions.Expression, System.Linq.Expressions.Expression, System.Linq.Expressions.Expression> merge)
        {
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            return System.Linq.Expressions.Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        #endregion

        #region And(与表达式)

        /// <summary>
        /// 与操作表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        public static Expression And(this Expression left, Expression right)
        {
            if (left == null)
                return right;
            if (right == null)
                return left;
            return Expression.AndAlso(left, right);
        }

        /// <summary>
        /// 与操作表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null)
                return right;
            if (right == null)
                return left;
            return left.Compose(right, Expression.AndAlso);
        }

        #endregion

        #region Or(或表达式)

        /// <summary>
        /// 或操作表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        public static Expression Or(this Expression left, Expression right)
        {
            if (left == null)
                return right;
            if (right == null)
                return left;
            return Expression.OrElse(left, right);
        }

        /// <summary>
        /// 或操作表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null)
                return right;
            if (right == null)
                return left;
            return left.Compose(right, Expression.OrElse);
        }

        #endregion
    }
}