using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LumoTrack.API.Helpers
{
    public class NinjectHelper: System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectHelper()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this._kernel.Bind<HttpClient>().ToSelf(); // Registering Types    
        }
    }
}