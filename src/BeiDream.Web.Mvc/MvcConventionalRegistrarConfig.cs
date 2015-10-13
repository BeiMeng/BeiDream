

namespace BeiDream.Web.Mvc
{
    /// <summary>
    /// Mvc的依赖注入选项配置文件
    /// </summary>
    public class MvcConventionalRegistrarConfig
    {
        /// <summary>
        /// 是否对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册(默认为true)
        /// </summary>
        public bool RegistrarForInterface { get; set; }

        //public MvcConventionalRegistrarConfig()
        //{
        //    RegistrarForInterface = true;
        //}
        public MvcConventionalRegistrarConfig(bool registrarForInterface=true)
        {
            RegistrarForInterface = registrarForInterface;
        }
    }
}