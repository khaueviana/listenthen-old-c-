using System.ComponentModel.DataAnnotations;

namespace ListenThen.Infra.CrossCutting.Identity.Models.AccountViewModel
{
    public class PasswordResetTokenViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        public string Token { get; set; }
    }
}