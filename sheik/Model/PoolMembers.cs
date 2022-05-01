using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class PoolMembers
    {
        [Key]
        public int PoolMemberId{get; set;}

        [ForeignKey("Pool")]
        public int PoolId {get; set;}
        public Pool Pool {get; set;}

        [ForeignKey("Employee")]
        public int EmployeeId {get; set;}
        public Employee Employee {get; set;}

    }
}