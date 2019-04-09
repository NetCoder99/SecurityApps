using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityWeb.Common
{
    public class GetModelErrors
    {
        public static Dictionary<String, String> GetErrors<T>(T modelState) where T : System.Web.Mvc.ModelStateDictionary
        {
            Dictionary<String, String> rtn_dict = new Dictionary<string, string>();
            foreach (var model_entry in modelState)
            {
                if (model_entry.Value.Errors.Count() > 0)
                { rtn_dict.Add(model_entry.Key, model_entry.Value.Errors[0].ErrorMessage); }
            }
            return rtn_dict;
        }
    }
}