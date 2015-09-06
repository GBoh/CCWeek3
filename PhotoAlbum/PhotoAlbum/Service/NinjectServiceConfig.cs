using Ninject;
using PhotoAlbum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Service {
    public class NinjectServiceConfig {
        public static void RegisterServices (IKernel kernel) {
            NinjectInfrastructureConfig.RegisterServices(kernel);

            kernel.Bind<AlbumService>().ToSelf();
        }
    }
}