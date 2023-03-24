using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Utils;

public static class MvcOptionsExtensions
{
    public static void UseRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
    {
        opts.Conventions.Add(new RoutePrefixConvention(routeAttribute));
    }

    public static void UseRoutePrefix(this MvcOptions opts, string
    prefix)
    {
        opts.UseRoutePrefix(new RouteAttribute(prefix));
    }
}