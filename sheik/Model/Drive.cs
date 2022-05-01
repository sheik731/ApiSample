using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class Drive
    {
        [Key]
        public int DriveId {get; set;}
        [Required]
        [StringLength(25)]
        public string DriveName  { get; set; }
        public int FromDate {get; set;}
        public int ToDate {get; set;}

        [ForeignKey("Pool")]
        public int PoolId {get; set;}
        public Pool Pool {get; set;}

        public int Mode {get; set;}

        [ForeignKey("Location")]
        public int LocationId {get; set;}
        public Location Location {get; set;}

        [Required]
        public bool IsScheduled { get; set;} = true;

        public string CancelReason {get; set;}

        [Required]
        public bool IsDriveCancelled {get; set;} = true;

        public int AddedBy {get; set;}
        public int AddedOn {get; set;}
        public int UpdatedBy {get; set;}
        public int UpdatedOn {get; set;}
        public int SlotTiming {get; set;}
        
    }
}