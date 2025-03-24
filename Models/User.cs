
using System.ComponentModel.DataAnnotations;

namespace CoreWebServer.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(0.01, 10000.00)]
        public decimal Average {  get; set; }
    }
}
