using System;
using Unity;

namespace BlogSpot.Utils
{
    public interface IDependencyInjector : IDisposable
    {
        UnityContainer GetDependencyContainer { get; }
    }
}
