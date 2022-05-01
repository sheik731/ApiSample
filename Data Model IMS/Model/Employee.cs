using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace sample.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId{get; set;}

        [ForeignKey("Project")]
        public int ProjectId {get; set;}
        public Project Project {get; set;}

        [Required]
        public string EmployeeAceNumber {get; set;}
        [Required]
        [StringLength(25)]
        public string EmployeeName  { get; set; }

        [ForeignKey("Dept")]
        public int DeptId {get; set;}
        public Dept Dept {get; set;}

        [ForeignKey("Role")]
        public int RoleId {get; set;}
        public Role Role {get; set;}

        public String EmailId {get; set;}
        public String Password {get; set;}


        [Required]
        public bool IsActive { get; set;} = true;

        [Required]
        public bool IsAdminAccepted { get; set;} = true;

        [Required]
        public string IsAdminResponded {get; set;}
    }
}