using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class Role
    {
        [Key]
        public int RoleId{get; set;}
        [Required]
        [StringLength(25)]
        public string RoleName  { get; set; }
        [Required]
        public bool IsActive { get; set;} = true;

    }
}