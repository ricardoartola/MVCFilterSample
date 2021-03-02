using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilterSample.Filters
{
    public class LogAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            string ip = filterContext.HttpContext.Request.UserHostAddress;
            DateTime date = filterContext.HttpContext.Timestamp;

            string path = filterContext.HttpContext.Server.MapPath("~/Log/log.txt");
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine();
                sw.Write("Controller:" + controller);
                sw.Write(",Action:" + action);
                sw.Write(",IP:" + ip);
                sw.Write(",Date:" + date.ToLongDateString());
            }
        }
    }
}