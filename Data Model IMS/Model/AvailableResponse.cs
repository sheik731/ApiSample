using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class AvailableResponse
    {
        [Key]
        public int AvailableResponseId{get; set;}

        [ForeignKey("Drive")]
        public int DriveId {get; set;}
        /*public Drive Drive {get; set;}*/

        [ForeignKey("Employee")]
        public int EmployeeId {get; set;}
        // public Employee Employee {get; set;}

        public int Date {get; set;}
        public int FromDate {get; set;}
        public int ToDate {get; set;}

        [Required]
        public bool IsScheduled { get; set;} = true;

        [Required]
        public bool IsInterviewCanceled { get; set;} = true;

        [ForeignKey("CancellationReason")]
        public int CancellationReasonId {get; set;}
        public CancellationReason CancellationReason {get; set;}

        [Required]
        public string Comments {get; set;}

        public virtual ICollection<Employee>? Employees {get; set;}
        public virtual ICollection<Drive>? Drives {get; set;}

    }
}