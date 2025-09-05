using System.ComponentModel.DataAnnotations;

namespace Day1
{
    public class Product
    {
        [Required]
        [Range(1,1000)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
