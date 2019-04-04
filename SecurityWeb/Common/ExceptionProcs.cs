using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SecurityWeb.Common
{
    public class ExceptionProcs
    {
        public static string GetExceptionMessage(Exception ex)
        {
            if (ex.InnerException != null)
            { return GetExceptionMessage(ex.InnerException); }
            return ex.Message;
        }
        public static string GetExceptionMessage(DbEntityValidationException ex)
        {
            return ex.EntityValidationErrors.ToList()[0].ValidationErrors.ToList()[0].ErrorMessage;
        }
    }
}