using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimformWeb.Models
{
    public class EmployeeEntity : BaseEntity
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Joining Date is required")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1000, int.MaxValue, ErrorMessage = "Please Enter Min 1000 value")]
        public decimal Salary { get; set; }

        public string JoiningDateString { get; set; }

        public string FullName
        {
            get
            {
             return  this.FirstName + " " + this.LastName;
            }
        }
    }
}
