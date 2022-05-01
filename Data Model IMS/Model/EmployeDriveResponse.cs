using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class EmployeeDriveResponse
    {
        [Key]
        public int ResponseId{get; set;}

        [ForeignKey("Drive")]
        public int DriveId {get; set;}
        public Drive Drive {get; set;}

        [ForeignKey("Employee")]
        public int EmployeeId {get; set;}
        public Employee Employee {get; set;}

        public int ResponseType {get; set;}

    }
}