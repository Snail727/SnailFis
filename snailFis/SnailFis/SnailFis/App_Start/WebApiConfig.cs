using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using SnailFis.Common;
using SnailFis.Controllers;

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

            config.Filters.Add(new ApiResultAttribute());
            config.Filters.Add(new ApiExceptionResultAttribute());
            //移除xml返回格式数据
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

        /// <summary>
        /// API正常返回
        /// </summary>
        public class ApiResultAttribute : ActionFilterAttribute
        {
            private string GetValueFromDic(Dictionary<string, string> dic, string key)
            {
                if (dic.TryGetValue(key, out string val))
                {
                    return val;
                }
                return string.Empty;
            }
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var dic = actionContext.Request.Headers.ToDictionary(t => t.Key.ToLower(), t => t.Value.FirstOrDefault());
                var auth = GetValueFromDic(dic, "authorization");
                var userMsg = TokenHelper.DecodeToken(auth);
                if (userMsg.Success) { CommonSettings.TokenData = (TokenInfo)userMsg.Data;CommonSettings.UserSn = CommonSettings.TokenData.UserSn; }
                else {
                    if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count <= 0)
                    {
                        throw new HttpResponseException(HttpStatusCode.Unauthorized);
                    }
                }

            }
        }

        /// <summary>
        /// API异常返回
        /// </summary>
        public class ApiExceptionResultAttribute : ExceptionFilterAttribute
        {
            /// <summary>
            /// 异常信息包装
            /// </summary>
            /// <param name="actionExecutedContext"></param>
            public override void OnException(HttpActionExecutedContext actionExecutedContext)
            {
                base.OnException(actionExecutedContext);
                LogHelper.WriteLog("WebApiConfig", actionExecutedContext.Exception);
                //if (actionExecutedContext.Exception is TokenException)
                //{
                //    var tokenResult = new ApiResultModel()
                //    {
                //        StatusCode = HttpStatusCode.Unauthorized,
                //        Success = false,
                //        Message = "身份信息已过期，请重新登录"
                //    };
                //    HttpResponseMessage tokenHttpResponseMessage = new HttpResponseMessage
                //    {
                //        Content = new StringContent(JsonConvert.SerializeObject(tokenResult), Encoding.GetEncoding("UTF-8"), "application/json")
                //    };
                //    actionExecutedContext.Response = tokenHttpResponseMessage;
                //    return;
                //}

                //ApiResultModel result = new ApiResultModel
                //{
                //    StatusCode = actionExecutedContext.ActionContext.Response?.StatusCode ?? HttpStatusCode.InternalServerError,

                //    Data = actionExecutedContext.Exception.Data,
                //    Success = actionExecutedContext.ActionContext.Response?.IsSuccessStatusCode ?? false,
                //    Message = actionExecutedContext.Exception?.Message
                //};

                //HttpResponseMessage httpResponseMessage = new HttpResponseMessage
                //{
                //    Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.GetEncoding("UTF-8"), "application/json")
                //};
                //actionExecutedContext.Response = httpResponseMessage;
            }
        }

        /// <summary>
        /// 返回类型
        /// </summary>
        public class ApiResultModel
        {
            /// <summary>
            /// 状态码
            /// </summary>
            public HttpStatusCode StatusCode { get; set; }
            /// <summary>
            /// 数据
            /// </summary>
            public object Data { get; set; }
            /// <summary>
            /// 是否成功
            /// </summary>
            public bool Success { get; set; }
            /// <summary>
            /// 返回的消息
            /// </summary>
            public string Message { get; set; }
        }
    }
}
