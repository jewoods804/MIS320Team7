using System.Web;
using System.Web.Mvc;

namespace MIS320_Team7Project_Fall2016
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
