﻿using System;
using LocalApi.Routing;

namespace LocalApi
{
    class HttpRequestContext : IDisposable
    {
        public HttpConfiguration Configuration { get; }
        public HttpRoute MatchedRoute { get; }
        
        public HttpRequestContext(HttpConfiguration configuration, HttpRoute matchedRoute)
        {
            Configuration = configuration;
            MatchedRoute = matchedRoute;
        }

        #region Please implement the following method

        /*
         * For each http context, at most one dependency scope will be created. In
         * this method, you should create and cache dependency scope.
         * 
         * Since the dependency scope manages all the object lifetimes. So we have
         * to dispose it when request context finished.
         * 
         * You can create non-public fields if needed.
         */

        private IDependencyScope scop;
        public IDependencyScope GetDependencyScope()
        {
            if (scop == null)
            {
                scop = Configuration.DependencyResolver.BeginScope();
            }

            return scop;
        }

        public void Dispose()
        {
            scop.Dispose();
        }

        #endregion
    }
}