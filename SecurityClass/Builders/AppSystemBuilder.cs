using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using SecurityClass.Models;
using Newtonsoft.Json;
using System.IO;

namespace SecurityClass.Builders
{
    //public class AppSystemBuilder 
    //{
    //    protected AppSystem appSystem = new AppSystem();

    //    public AppSystemBuilder() { }
    //    public AppSystemBuilder(string jsonModel)
    //    {
    //        JsonReader jsonReader = new JsonTextReader(new StringReader(jsonModel));
    //        while (jsonReader.Read())
    //        {
    //            if (jsonReader.Value != null)
    //            {
    //                Console.WriteLine("Token: {0}, Value: {1}", jsonReader.TokenType, jsonReader.Value);
    //                switch (jsonReader.Path)
    //                {
    //                    case "Id":
    //                        appSystem.Id = (string)jsonReader.Value;
    //                        break;
    //                    case "AppId":
    //                        appSystem.AppId = (int)jsonReader.Value;
    //                        break;
    //                    case "Name":
    //                        appSystem.Name = (string)jsonReader.Value;
    //                        break;
    //                    case "Desc":
    //                        appSystem.Desc = (string)jsonReader.Value;
    //                        break;
    //                    default:
    //                        break;
    //                }
    //            }
    //        }

    //    }

    //    public AppSystem GetAppSystem()
    //    {
    //        return this.appSystem;
    //    }
    //}
}
