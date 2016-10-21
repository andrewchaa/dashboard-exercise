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

            var kernel = new StandardKernel();
            kernel.Bind<IConfig>().To<Config>();
            kernel.Bind<IPnLRepository>().To<PnLRepository>();

            var repository = kernel.Get<IPnLRepository>();
            foreach (var line in lines)
            {
                var columns = line.Split(',');
                Console.WriteLine(columns[0]);
                var date = DateTime.ParseExact(columns[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                for (int i = 1; i < 16; i++)
                {
                    var pnl = new PnL {Amount = decimal.Parse(columns[i]), Strategy = i, Date = date};
                    repository.Add(pnl);
                }
            }
        }
    }
}
