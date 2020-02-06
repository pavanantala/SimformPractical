using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimformWeb.Models
{
    public class ProjectEntity : BaseEntity
    {
        [Required(ErrorMessage ="Project Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Enter Cost")]
        [Range(10,int.MaxValue,ErrorMessage ="Please Enter Min 10 value")]
        public decimal Cost { get; set; }
    }
}
