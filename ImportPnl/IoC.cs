using Dashboard.App.Domain.Repositories;
using Dashboard.App.Domain.Services;
using Ninject;

namespace Dashboard.App.ImportPnl
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
