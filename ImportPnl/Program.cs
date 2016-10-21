using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dashboard.App.ImportPnl.Domain.Models;
using Dashboard.App.ImportPnl.Domain.Services;
using Dashboard.App.ImportPnl.Infrastructure;
using Dashboard.App.ImportPnl.Repositories;
using Ninject;
using static System.Decimal;

namespace ImportPnl
{
    class Program
    {
        static void Main(string[] args)
        {            
            if (args.Length == 0)
                Console.WriteLine("Please specify the P&L file name to import");

            var lines = File.ReadAllLines(args[0]).Skip(1);

            var importer = IoC.Kernel.Get<IImportPnL>();
            importer.Import(lines);
        }
    }
}
