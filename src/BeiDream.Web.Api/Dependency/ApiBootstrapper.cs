using System.Web.Http;
using System.Web.Http.Dispatcher;
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
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new ApiControllerActivator(IocManager));
        }
    }
}