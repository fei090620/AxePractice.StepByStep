using System;
using LocalApi;

namespace Manualfac.LocalApiIntegration
{
    class ManualfacDependencyScope : IDependencyScope
    {
        #region Please implement the class

        /*
         * We should create a manualfac dependency scope so that we can integrate it
         * to LocalApi.
         * 
         * You can add a public/internal constructor and non-public fields if needed.
         */

        private ILifetimeScope root;
        public ManualfacDependencyScope(ILifetimeScope root)
        {
            this.root = root;
        }

        public void Dispose()
        {
            root.Disposer.Dispose();
        }

        public object GetService(Type type)
        {
            return root.Resolve(type);
        }

        #endregion
    }
}