using System.ComponentModel.DataAnnotations;

namespace StreamWorker.ViewModels.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }
}