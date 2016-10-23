using Dashboard.App.Domain.Contracts;
using Dashboard.App.Domain.Helpers;
using Dashboard.App.Domain.Repositories;
using Dashboard.App.Domain.Services;
using Ninject;

namespace Dashboard.App.ImportCapital
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
            _kernel.Bind<ICapitalRepository>().To<CapitalRepository>();
            _kernel.Bind<IImportDataCsv>().To<CapitalImporter>();
        }
    }
}
