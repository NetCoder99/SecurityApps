using SecurityWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityWeb.Models
{
    public class Error
    {
        public string errMessage { get; set; }
        public string stackTrace { get; set; }

        public Error() { }
        public Error(Exception exception)
        {
            this.errMessage = ExceptionProcs.GetExceptionMessage(exception);
            this.stackTrace = ExceptionProcs.GetStackTrace(exception);
        }

        public void Set(Exception exception)
        {
            this.errMessage = ExceptionProcs.GetExceptionMessage(exception);
            this.stackTrace = ExceptionProcs.GetStackTrace(exception);
        }
    }
}