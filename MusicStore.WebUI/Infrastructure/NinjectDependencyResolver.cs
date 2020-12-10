using MusicStore.Domain.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Moq;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Concrete;

namespace MusicStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        IKernel kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type type)
        {
            return kernel.TryGet(type);
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return kernel.GetAll(type);
        }

        public void AddBindings()
        {
            kernel.Bind<IMusicStoreRepository>().To<MusicStoreRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
        }
    }
}