using BeiDream.Core.Dependency;

namespace BeiDream.Core.Domain.Services
{
    /// <summary>
    /// 领域服务接口基类(实现依赖注入生命周期实例模式自动装配判断接口)
    /// </summary>
    public interface IDomainService : ITransientDependency
    {
    }
}