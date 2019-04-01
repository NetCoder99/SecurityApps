using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClass.Models
{
    public class AppSystem
    {

        [Key]
        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Desc { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<AppRole> AppRoles { get; set; }

        public AppSystem()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
