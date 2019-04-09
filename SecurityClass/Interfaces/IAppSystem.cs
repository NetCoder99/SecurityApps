using SecurityClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClass.Interfaces
{

    public class IAppSystem
    {
        public virtual string Id { get; set; }
        public virtual int AppId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Desc { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        public virtual ICollection<AppRole> AppRoles { get; set; }
    }

}
