using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoWeb.Filters {


    // Extending HandleError

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ContosoExceptionFilter : HandleErrorAttribute {
        private readonly ILog _logger;

        public ContosoExceptionFilter() {
            _logger = LogManager.GetLogger("ContosoLogger");
        }

        public override void OnException(ExceptionContext filterContext) {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            filterContext.Result = new ViewResult {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };

            var dateExceptionHappened = DateTime.Now.TimeOfDay.ToString();
            //set breakpoing on the following line to see what the requested path and query is
            var pathAndQuery = filterContext.HttpContext.Request.Path + filterContext.HttpContext.Request.QueryString;

            // throw new FileNotFoundException();
            // log the error using log4net.
            XmlConfigurator.Configure();

            _logger.Error("Logging Exception using Log4Net", filterContext.Exception);
            _logger.Error(string.Format("The controller that gives that exception is {0}", controllerName));
            _logger.Error(string.Format("The action that gives that exception is {0}", actionName));
            _logger.Error(string.Format("The time is {0}", DateTime.Now));


            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            base.OnException(filterContext);
        }
    }
}