using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Iswarya.Models
{
    public class User
    {
        [Key]
        public int UserId{get; set;}
        [Required]
        [StringLength(25)]
        public string userName  { get; set; }
        
        
        
    }
}