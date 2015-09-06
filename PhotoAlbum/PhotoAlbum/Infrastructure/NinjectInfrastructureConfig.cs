using Ninject;
using PhotoAlbum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Infrastructure {
    public class NinjectInfrastructureConfig {
        public static void RegisterServices (IKernel kernel) {

            kernel.Bind<IRepository>().To<Repository>();
            kernel.Bind<DataContext>().ToSelf();
        }
    }
}