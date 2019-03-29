﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityClass.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { } 
        public AppRole(string name) : base(name) { }

        [NotMapped]
        public string RoleName { get { return base.Name; } } 

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }
    }
}