using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using Newtonsoft.Json;

namespace SnailFis
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //设置webapi路由规则
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "snailFis_api/{controller}/{action}"
            );


            //移除xml返回格式数据
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
