using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerlitzTest.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductNumber { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
