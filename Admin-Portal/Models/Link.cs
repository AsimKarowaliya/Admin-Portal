using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Portal.Models
{
    public class Link
    {
        [Key]
        public string ID { get; set; }


        public string LinkName { get; set; }

        
        public string RoleName { get; set; }

        
        public IdentityRole Roles { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> selectLists { get; set; }


       
    }
}
