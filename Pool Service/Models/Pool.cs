using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class Pool
    {
        [Key]
        public int PoolId{get; set;}
        [Required]
        [StringLength(25)]
        public string PoolName  { get; set; }
        [Required]
        public bool IsActive { get; set;} = true;
        
        [ForeignKey("Department")]
        public int DeptId {get; set;}
        public Dept Dept {get; set;}

        public virtual ICollection<PoolMembers>? PoolMembers {get; set;}

    }
}