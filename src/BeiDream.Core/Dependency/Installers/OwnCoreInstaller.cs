using BeiDream.Core.Events.Bus.EventBus.Config;
using BeiDream.Utils.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BeiDream.Core.Dependency.Installers
{

    internal class OwnCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IEventBusConfiguration, EventBusConfiguration>().ImplementedBy<EventBusConfiguration>().LifestyleSingleton(),
                Component.For<ITypeFinder>().ImplementedBy<TypeFinder>().LifestyleSingleton()
                );
        }
    }
}