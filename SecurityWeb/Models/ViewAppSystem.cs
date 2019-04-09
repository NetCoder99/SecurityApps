using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecurityWeb.Models
{
    public class ViewAppSystem : SecurityClass.Interfaces.IAppSystem
    {
        [Required(ErrorMessage = "Name is a required field")]
        [DisplayName("Name:")]
        public override string Name { get => base.Name; set => base.Name = value; }

        [Required(ErrorMessage = "Description is a required field")]
        [DisplayName("Description:")]
        public override string Desc { get => base.Desc; set => base.Desc = value; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public override DateTime CreateDate { get => base.CreateDate; set => base.CreateDate = value; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public override DateTime UpdateDate { get => base.UpdateDate; set => base.UpdateDate = value; }

        public ViewAppSystem(SecurityClass.Interfaces.IAppSystem appSystem)
        {
            if (appSystem != null)
            {
                this.Id = appSystem.Id;
                this.AppId = appSystem.AppId;
                this.Name = appSystem.Name;
                this.Desc = appSystem.Desc;
                this.CreateDate = appSystem.CreateDate;
                this.UpdateDate = appSystem.UpdateDate;

                //public virtual ICollection<AppRole> AppRoles { get; set; }
            }

        }

    }
}