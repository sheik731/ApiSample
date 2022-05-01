using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class CancellationReason
    {
        [Key]
        public int CancellationReasonId{get; set;}
        
        [Required]
        public string GetCancellationReason {get; set;}

    }
}