using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityConsole
{
    public static class ExceptionProcs
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
