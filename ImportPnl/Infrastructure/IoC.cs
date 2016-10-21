using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.App.ImportPnl.Domain.Services;
using Dashboard.App.ImportPnl.Repositories;
using Ninject;

namespace Dashboard.App.ImportPnl.Infrastructure
{
    public class IoC
    {
        private static IKernel _kernel;

        public static IKernel Kernel
        {
            get
            {
                if (_kernel == null)
                {
                    Initialize();
                }

                return _kernel;
            }
        }

        private static void Initialize()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IConfig>().To<Config>();
            _kernel.Bind<IPnLRepository>().To<PnLRepository>();
            _kernel.Bind<IImportPnL>().To<PnLImporter>();
        }
    }
}
