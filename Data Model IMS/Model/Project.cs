using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace sample.Model
{
    public class Project
    {
        [Key]
        public int ProjectId{get; set;}
        [Required]
        [StringLength(25)]
        public string ProjectName  { get; set; }
        [Required]
        public bool IsActive { get; set;} = true;
        [ForeignKey("Department")]
        public int DeptId {get; set;}
        public Dept Dept {get; set;}
    }
}