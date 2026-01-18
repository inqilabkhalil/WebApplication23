using System.ComponentModel.DataAnnotations;

namespace WebApplication23.Models
{
    public class Worker : BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
