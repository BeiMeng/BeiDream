using System;

namespace BeiDream.Utils.Reflection
{
    public interface ITypeFinder
    {
        IAssemblyFinder AssemblyFinder { get; set; }
        Type[] Find(Func<Type, bool> predicate);

        Type[] FindAll();
    }
}