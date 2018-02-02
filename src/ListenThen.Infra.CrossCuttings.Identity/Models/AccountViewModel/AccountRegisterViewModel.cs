using System.ComponentModel.DataAnnotations;

namespace ListenThen.Infra.CrossCutting.Identity.Models.AccountViewModel
{
    public class AccountRegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}