using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Employee_Datamodel.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone_No { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public float Salary { get; set; }
    }
}
