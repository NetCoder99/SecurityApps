using SecurityClass.Classes;
using SecurityClass.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClass.Models
{
    public class AppSystem : IAppSystem
    {

        [Key]
        [Required]
        [StringLength(128)]
        public override string Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int AppId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public override string Name { get; set; }

        [Required]
        [StringLength(250)]
        public override string Desc { get; set; }

        [Required]
        public override DateTime CreateDate { get; set; }

        public override DateTime UpdateDate { get; set; }

        public override ICollection<AppRole> AppRoles { get; set; }

        //public AppSystem()
        //{
        //    //this.Id = Guid.NewGuid().ToString();
        //}


    }
}
