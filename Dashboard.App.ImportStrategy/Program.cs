using System;
using System.IO;
using System.Linq;
using Dashboard.App.Domain.Contracts;
using Ninject;

namespace Dashboard.App.ImportStrategy
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
