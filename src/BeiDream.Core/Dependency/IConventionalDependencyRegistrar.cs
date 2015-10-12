namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 具体依赖注入实现类的接口
    /// </summary>
    public interface IConventionalDependencyRegistrar
    {
        void RegisterAssembly(IConventionalRegistrationContext context);
    }
}