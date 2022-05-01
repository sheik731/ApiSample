using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Model
{
    public class Location
    {
        [Key]
        public int LocationId{get; set;}
        [Required]
        [StringLength(25)]
        public string LocationName  { get; set; }
        [Required]
        public bool IsActive { get; set;} = true;

    }
}