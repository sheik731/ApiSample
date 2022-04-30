using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class Dept
    {
        [Key]
        public int DeptId{get; set;}
        [Required]
        [StringLength(25)]
        public string DeptName  { get; set; }
        [Required]
        public bool IsActive { get; set;} = true;

    }
}