using System;
using Unity;

namespace BlogSpot.Api.Utils
{
    public interface IDependencyInjector : IDisposable
    {
        UnityContainer GetDependencyContainer { get; }
    }
}
