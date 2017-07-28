using System;

namespace Manualfac
{
    class RootScopeLifetime : IComponentLifetime
    {
        public ILifetimeScope FindLifetimeScope(ILifetimeScope mostNestedLifetimeScope)
        {
            #region Please implement this method

            /*
             * This class will always create and share instaces in root scope.
             */

            ILifetimeScope rootScop = mostNestedLifetimeScope;
            while (mostNestedLifetimeScope != null)
            {
                rootScop = mostNestedLifetimeScope;
                mostNestedLifetimeScope = mostNestedLifetimeScope.RootScope;
            }

            return rootScop;

            #endregion
        }
    }
}