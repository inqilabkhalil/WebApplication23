using System.ComponentModel.DataAnnotations;

namespace WebApplication23.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Work { get; set; }
        public IEnumerable<Worker> Workers {get; set;}
        
    }
}
