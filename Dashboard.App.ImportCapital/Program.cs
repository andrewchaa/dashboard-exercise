using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dashboard.App.Domain.Contracts;
using Dashboard.App.Domain.Services;
using Ninject;
using NLog;

namespace Dashboard.App.ImportCapital
{
    class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("Please specify the capital file name you want to import");

            var lines = File.ReadAllLines(args[0]).Skip(1);

            Logger.Info("Importing capital data of {0} lines", lines.Count());

            var importer = IoC.Kernel.Get<IImportDataCsv>();
            importer.Import(lines);

        }
    }

}
