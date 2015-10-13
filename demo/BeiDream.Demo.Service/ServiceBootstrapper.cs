using System.Reflection;
using BeiDream.Core.Dependency;

namespace BeiDream.Demo.Service
{
    public class ServiceBootstrapper:Bootstrapper
    {

        public ServiceBootstrapper() : base(Assembly.GetExecutingAssembly())
        {   
            
        }
    }
}