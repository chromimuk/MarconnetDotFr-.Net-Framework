using MarconnetDotFr_DernierFM.Models;
using MarconnetDotFr_DernierFM.Repository;
using MarconnetDotFr_MVC.Models.Repos;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarconnetDotFr_MVC.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel k)
        {
            kernel = k;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IResumeRepository>().To<XMLFilesResumeRepository>();
            kernel.Bind<IWorkRepository>().To<XMLFilesWorkRepository>();

            // lastfm
            string apiKey = System.Configuration.ConfigurationManager.AppSettings["lastfm_APIKey"];
            string sharedSecret = System.Configuration.ConfigurationManager.AppSettings["lastfm_SharedSecret"];
            LastFMCredentials lastFMCredentials = new LastFMCredentials(apiKey, sharedSecret);
            kernel.Bind<ILastFMRepository>().To<LastFMRepository>().WithConstructorArgument("lastFMCredentials", lastFMCredentials);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}