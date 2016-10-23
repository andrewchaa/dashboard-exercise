using System.Web;
using System.Web.Mvc;

namespace Dashboard.Api.DataStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
