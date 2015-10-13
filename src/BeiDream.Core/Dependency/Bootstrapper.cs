using System.Reflection;

namespace BeiDream.Core.Dependency
{
    public class Bootstrapper
    {
        public IIocManager IocManager { get; private set; }
        public Assembly Assembly { get; private set; }
        public Bootstrapper(Assembly assembly)
        {
            IocManager = Dependency.IocManager.Instance;
            Assembly = assembly;

        }

        public virtual void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly);
        }
    }
}