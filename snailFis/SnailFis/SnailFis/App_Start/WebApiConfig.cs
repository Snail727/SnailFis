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
            //移除xml返回格式数据
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

        /// <summary>
        /// API正常返回
        /// </summary>
        public class ApiResultAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var dic = actionContext.Request.Headers.ToDictionary(t => t.Key.ToLower(), t => t.Value.FirstOrDefault());

            }
        }
    }
}

//using LemonScm.Common;
//using LemonScm.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Web.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace LemonScm.WebApi
//{
//    /// <summary>
//    /// WebApi配置
//    /// </summary>
//    public static class WebApiConfig
//    {
//        /// <summary>
//        /// 注册路由
//        /// </summary>
//        /// <param name="config"></param>
//        public static void Register(HttpConfiguration config)
//        {
//            // Web API 配置和服务

//            // Web API 路由
//            config.MapHttpAttributeRoutes();

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "jxc_api/{controller}/{action}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );
//            config.Filters.Add(new ApiResultAttribute());
//            config.Filters.Add(new ApiExceptionResultAttribute());
//        }
//    }
//    /// <summary>
//    /// API正常返回
//    /// </summary>
//    public class ApiResultAttribute : ActionFilterAttribute
//    {
//        private string GetValueFromDic(Dictionary<string, string> dic, string key)
//        {
//            if (dic.TryGetValue(key, out string val))
//            {
//                return val;
//            }
//            return string.Empty;
//        }

//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            var dic = actionContext.Request.Headers.ToDictionary(t => t.Key.ToLower(), t => t.Value.FirstOrDefault());
//            var auth = GetValueFromDic(dic, "authorization");
//            var authCode = GetValueFromDic(dic, "authcode");

//            if (string.IsNullOrEmpty(auth) && string.IsNullOrEmpty(authCode))
//            {
//                if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count <= 0)
//                {
//                    DebugLog.Log.Debug(GetType(), string.Join("\r\n", dic.Select(t => t.Value)));
//                    throw new InvalidOperationException("未知错误，请联系侧边栏客服或刷新浏览器再试");
//                }
//            }

//            //获取登陆用户的Token
//            Business.Maintain.CommonSettings.Authorization = auth;

//            base.OnActionExecuting(actionContext);
//        }
//        /// <summary>
//        /// 包装成统一格式返回
//        /// </summary>
//        /// <param name="actionExecutedContext"></param>
//        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
//        {
//            base.OnActionExecuted(actionExecutedContext);

//            if (actionExecutedContext.Exception is NewApiScmException)
//            {
//                DealwithNewApiScmException(actionExecutedContext);
//                return;
//            }

//            ApiResultModel result = new ApiResultModel();

//            if (actionExecutedContext.ActionContext.Response == null)
//            {
//                result.StatusCode = HttpStatusCode.OK;
//            }
//            else
//            {
//                result.StatusCode = actionExecutedContext.ActionContext.Response.StatusCode;
//            }
//            var controller = actionExecutedContext.ActionContext.ControllerContext.Controller;
//            if (controller is BaseApiController)
//            {
//                var bac = controller as BaseApiController;
//                if (bac.ExceptionData != null && bac.ExceptionData.Count > 0)
//                {
//                    result.Success = false;
//                    result.Data = bac.ExceptionData;
//                }
//                else
//                {
//                    result.Success = true;
//                    var response = actionExecutedContext.ActionContext.Response;
//                    if (response != null)
//                    {
//                        if (response.Content is ByteArrayContent || response.Content is StreamContent)
//                        {
//                            actionExecutedContext.Response = response;
//                            return;
//                        }
//                        result.Data = response.Content?.ReadAsAsync<object>()?.Result;
//                    }
//                }
//                if (actionExecutedContext.Exception != null)
//                {
//                    DebugLog.Log.Error(GetType(), $"{actionExecutedContext.Exception.Message}\r\n{actionExecutedContext.Exception.StackTrace}");
//                }
//                if (bac.ExceptionMessages == null || bac.ExceptionMessages.Count <= 0)
//                {
//                    result.Success = string.IsNullOrEmpty(actionExecutedContext.Exception?.Message);
//                    if (result.Success == false)
//                    {
//                        result.Message = actionExecutedContext.Exception?.Message;
//                    }
//                }
//                else
//                {
//                    result.Message = JsonHelper.ToJson(bac.ExceptionMessages);
//                }
//                if (result.Data != null && result.Data.GetType() == typeof(MessageModel))
//                {
//                    var d = result.Data as MessageModel;
//                    result.Success = d.Success;
//                    result.Data = d.Data;
//                    result.Message = d.Msg;

//                    if (d.Data is ErrorListModel)
//                    {
//                        var e = d.Data as ErrorListModel;
//                        e.FillBaseData(bac.AsId, bac.UserSn, bac.AsCommonSettings.AsStartDate, bac.AsCommonSettings.LastCheckOutDate);
//                        if (!string.IsNullOrEmpty(e.errorStr))
//                        {
//                            result.Message = e.errorStr;
//                        }
//                    }
//                    //result.StatusCode = (HttpStatusCode)d.StatusCode;
//                }
//            }
//            else
//            {
//                result.Data = actionExecutedContext.ActionContext.Response?.Content?.ReadAsAsync<object>().Result;
//                result.Success = actionExecutedContext.ActionContext.Response?.IsSuccessStatusCode ?? false;
//            }

//            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
//            {
//                Content = new StringContent(JsonHelper.ToJson(result), Encoding.GetEncoding("UTF-8"), "application/json")
//            };
//            actionExecutedContext.Response = httpResponseMessage;
//        }
//        /// <summary>
//        /// 处理可预知异常
//        /// </summary>
//        /// <param name="actionExecutedContext"></param>
//        private void DealwithNewApiScmException(HttpActionExecutedContext actionExecutedContext)
//        {
//            var except = actionExecutedContext.Exception as NewApiScmException;
//            ApiResultModel result = new ApiResultModel();
//            result.StatusCode = HttpStatusCode.OK;
//            result.Success = false;
//            result.Message = except.Message;
//            result.Data = except.ErrorListModel;
//            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
//            {
//                Content = new StringContent(JsonHelper.ToJson(result), Encoding.GetEncoding("UTF-8"), "application/json")
//            };
//            actionExecutedContext.Response = httpResponseMessage;
//        }
//    }
//    /// <summary>
//    /// API异常返回
//    /// </summary>
//    public class ApiExceptionResultAttribute : ExceptionFilterAttribute
//    {
//        /// <summary>
//        /// 异常信息包装
//        /// </summary>
//        /// <param name="actionExecutedContext"></param>
//        public override void OnException(HttpActionExecutedContext actionExecutedContext)
//        {
//            base.OnException(actionExecutedContext);
//            ApiResultModel result = new ApiResultModel();
//            result.StatusCode = actionExecutedContext.ActionContext.Response?.StatusCode ?? HttpStatusCode.InternalServerError;
//            //{
//            result.Data = actionExecutedContext.Exception.Data;
//            result.Success = actionExecutedContext.ActionContext.Response?.IsSuccessStatusCode ?? false;
//            result.Message = actionExecutedContext.Exception?.Message;
//            //}
//            if (actionExecutedContext.Exception != null)
//            {
//                DebugLog.Log.Error(GetType(), $"{actionExecutedContext.Exception.Message}\r\n{actionExecutedContext.Exception.StackTrace}");
//            }
//            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
//            {
//                Content = new StringContent(JsonHelper.ToJson(result), Encoding.GetEncoding("UTF-8"), "application/json")
//            };
//            actionExecutedContext.Response = httpResponseMessage;
//        }
//    }
//    /// <summary>
//    /// 返回类型
//    /// </summary>
//    public class ApiResultModel
//    {
//        /// <summary>
//        /// 状态码
//        /// </summary>
//        public HttpStatusCode StatusCode { get; set; }
//        /// <summary>
//        /// 数据
//        /// </summary>
//        public object Data { get; set; }
//        /// <summary>
//        /// 是否成功
//        /// </summary>
//        public bool Success { get; set; }
//        /// <summary>
//        /// 返回的消息
//        /// </summary>
//        public string Message { get; set; }
//    }
//}
