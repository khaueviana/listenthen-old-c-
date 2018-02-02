using System.ComponentModel.DataAnnotations;

namespace ListenThen.Infra.CrossCutting.Identity.Models.AccountViewModel
{
    public class RequestPasswordResetTokenViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}