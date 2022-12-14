using System.ComponentModel.DataAnnotations;

namespace OOPShop.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        public double Balance { get; set; }
    }
}
