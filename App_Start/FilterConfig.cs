using System.Web;
using System.Web.Mvc;

namespace ADETQ2_PANCAKE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
