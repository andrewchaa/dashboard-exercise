using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.App.Board.Helpers
{
    public static class DecimalHelpers
    {
        public static IEnumerable<decimal> CumulativeSum(this IEnumerable<decimal> sequence)
        {
            decimal sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
                yield return sum;
            }
        }
    }
}