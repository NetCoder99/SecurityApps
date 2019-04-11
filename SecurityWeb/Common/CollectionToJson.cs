using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityWeb.Common
{
    public static class CollectionToJson
    {
        public static string ToJSON(this System.Web.Mvc.FormCollection collection)
        {
            var list = new Dictionary<string, string>();
            foreach (string key in collection.Keys)
            {
                list.Add(key, collection[key]);
            }
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);
        }
        public static string ToJSON(this SecurityClass.Models.AppSystem appSystem)
        {
            return new
            {
                appSystem.Id,
                appSystem.AppId,
                appSystem.Name,
                appSystem.Desc,
                CreateDate = appSystem.CreateDate.ToShortDateString() + " " + appSystem.CreateDate.ToShortTimeString(),
                UpdateDate = appSystem.UpdateDate.ToShortDateString() + " " + appSystem.UpdateDate.ToShortTimeString()
            }.ToString();

        }


    }
}