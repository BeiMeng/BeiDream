using System;

namespace BeiDream.Utils.Etc
{
    /// <summary>
    /// This class is used to simulate a Disposable that does nothing.
    /// </summary>
    public sealed class NullDisposable : IDisposable
    {
        public static NullDisposable Instance { get { return SingletonInstance; } }
        private static readonly NullDisposable SingletonInstance = new NullDisposable();

        private NullDisposable()
        {
            
        }

        public void Dispose()
        {

        }
    }
}