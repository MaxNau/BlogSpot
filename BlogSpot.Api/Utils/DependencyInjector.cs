using BlogSpot.Api.DAL;
using BlogSpot.Api.DAL.Repositories;
using System;
using Unity;

namespace BlogSpot.Api.Utils
{
    public class DependencyInjector : IDependencyInjector
    {
        private UnityContainer container;
        public DependencyInjector()
        {
            container = new UnityContainer();
            InjectDependencies();
        }

        private void InjectDependencies()
        {
            container.RegisterType<IBlogSpotContext, BlogSpotContext>();
            container.RegisterType<IPostsRepository, PostsRepository>();
        }

        public UnityContainer GetDependencyContainer
        {
            get
            {
                return container;
            }
            private set
            {
                container = value;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    container.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}