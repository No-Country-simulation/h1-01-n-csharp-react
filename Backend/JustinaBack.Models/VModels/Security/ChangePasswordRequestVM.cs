
using System.ComponentModel.DataAnnotations;


namespace JustinaBack.Models
{
    public class ChangePasswordRequestVM
    {
        [Required]
        public string? CurrentPassword { get; set; }
        [Required]
        public string? NewPassword { get; set; }
    }
}
