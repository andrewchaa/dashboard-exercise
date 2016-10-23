using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dashboard.App.Domain.Contracts;
using Dashboard.App.Domain.Services;
using Ninject;

namespace Dashboard.App.ImportCapital
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("Please specify the capital file name you want to import");

            var lines = File.ReadAllLines(args[0]).Skip(1);

            var importer = IoC.Kernel.Get<IImportDataCsv>();
            importer.Import(lines);

        }
    }

}
