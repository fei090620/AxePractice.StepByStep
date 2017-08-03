using System;
using LocalApi;

namespace Manualfac.LocalApiIntegration
{
    public class ManualfacDependencyResolver : IDependencyResolver
    {
        #region Please implement the following class

        /*
         * We should create a manualfac dependency resolver so that we can integrate it
         * to LocalApi.
         * 
         * You can add a public/internal constructor and non-public fields if needed.
         */

        private Container rootContainer;
        private ManualfacDependencyScope scop;
        public ManualfacDependencyResolver(Container rootScope)
        {
            rootContainer = rootScope;
        }

        public void Dispose()
        {
            scop.Dispose();
        }

        public object GetService(Type type)
        {
            return scop.GetService(type);
        }

        public IDependencyScope BeginScope()
        {
            scop = new ManualfacDependencyScope(rootContainer.BeginLifetimeScope());
            return scop;
        }

        #endregion
    }
}