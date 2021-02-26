using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ProductShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute());
        }
    }

    public class LocalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var lang = filterContext.HttpContext.Request.QueryString["lang"];
            if (lang != null && !string.IsNullOrWhiteSpace(lang))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            }
            else
            {
                var cookie = filterContext.HttpContext.Request.Cookies["Language"];
                var langHeader = string.Empty;
                if (cookie != null)
                {
                    langHeader = cookie.Value;
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                else
                {
                    langHeader = filterContext.HttpContext.Request.UserLanguages[0];
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                filterContext.RouteData.Values["lang"] = langHeader;
            }
            HttpCookie _cookie = new HttpCookie("Language", Thread.CurrentThread.CurrentUICulture.Name);
            _cookie.Expires = DateTime.Now.AddYears(1);
            filterContext.HttpContext.Response.SetCookie(_cookie);
            base.OnActionExecuting(filterContext);
        }
    }
}
