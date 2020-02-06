using System;
using System.Collections.Generic;
using System.Text;

namespace SimformWeb.Models
{
    public class EmployeeToProjectEntity : BaseEntity
    {
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string FullName { get; set; }
        public string JoiningDateString { get; set; }

    }
}
