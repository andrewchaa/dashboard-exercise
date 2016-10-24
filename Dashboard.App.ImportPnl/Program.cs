using System;
using System.IO;
using System.Linq;
using Dashboard.App.Domain.Contracts;
using Dashboard.App.ImportPnl;
using Ninject;
using NLog;

namespace ImportPnl
{
    class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Console.WriteLine("Importing P&Ls");

            if (args.Length == 0)
                Console.WriteLine("Please specify the P&L file name to import");

            var lines = File.ReadAllLines(args[0]).Skip(1);

            Logger.Info("Importing PnLs data of {0} lines", lines.Count());

            var importer = IoC.Kernel.Get<IImportDataCsv>();
            importer.Import(lines);
        }
    }
}
