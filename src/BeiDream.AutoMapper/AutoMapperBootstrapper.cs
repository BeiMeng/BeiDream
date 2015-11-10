using System.Reflection;
using BeiDream.Utils.Reflection;

namespace BeiDream.AutoMapper
{
    public class AutoMapperBootstrapper
    {

        private readonly ITypeFinder _typeFinder;

        private static bool _createdMappingsBefore;
        private static readonly object _syncObj = new object();

        public AutoMapperBootstrapper(IAssemblyFinder assemblyFinder=null)
        {
            _typeFinder = new TypeFinder();
            if (assemblyFinder != null)
                _typeFinder.AssemblyFinder = assemblyFinder;
        }

        public void Initialize()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            lock (_syncObj)
            {
                //We should prevent duplicate mapping in an application, since AutoMapper is static.
                if (_createdMappingsBefore)
                {
                    return;
                }

                FindAndAutoMapTypes();

                _createdMappingsBefore = true;
            }
        }

        private void FindAndAutoMapTypes()
        {
            var types = _typeFinder.Find(type =>
                type.IsDefined(typeof(AutoMapAttribute)) ||
                type.IsDefined(typeof(AutoMapFromAttribute)) ||
                type.IsDefined(typeof(AutoMapToAttribute))
                );


            foreach (var type in types)
            {
                AutoMapperHelper.CreateMap(type);
            }
        }
    }
}
