using BeiDream.Core.Dependency;

namespace BeiDream.Web.Api.Dependency
{
    public class ApiBootstrapper
    {
        public IIocManager IocManager { get; private set; }
        public ApiBootstrapper(IIocManager iocManager)
        {
            IocManager = iocManager;
        }
        public virtual void Initialize()
        {
            IocManager.AddConventionalRegistrar(new ApiControllerConventionalRegistrar());
        }
    }
}