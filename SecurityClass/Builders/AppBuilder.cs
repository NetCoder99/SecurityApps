using Newtonsoft.Json;
using SecurityClass.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClass.Builders
{
    public class AppBuilder
    {
        protected AppSystem appSystem = new AppSystem();

        public AppSystem Build()
        { return appSystem; }

        public AppSystem Build(string jsonModel)
        {
            JsonReader jsonReader = new JsonTextReader(new StringReader(jsonModel));
            while (jsonReader.Read())
            {
                if (jsonReader.Value != null)
                {
                    Console.WriteLine("Token: {0}, Value: {1}", jsonReader.TokenType, jsonReader.Value);
                    switch (jsonReader.Path)
                    {
                        case "Id":
                            appSystem.Id = (string)jsonReader.Value;
                            break;
                        case "AppId":
                            appSystem.AppId = (int)jsonReader.Value;
                            break;
                        case "Name":
                            appSystem.Name = (string)jsonReader.Value;
                            break;
                        case "Desc":
                            appSystem.Desc = (string)jsonReader.Value;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (string.IsNullOrEmpty(appSystem.Id))
            { appSystem.Id = Guid.NewGuid().ToString(); }

            return appSystem;
        }

        public AppBuilder AppName(string name)
        {
            this.appSystem.Name = name;
            return this;
        }
        public AppBuilder AppDesc(string desc)
        {
            this.appSystem.Desc = desc;
            return this;
        }

    }
}
