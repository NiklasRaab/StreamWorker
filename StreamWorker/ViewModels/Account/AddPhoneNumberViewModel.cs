using System.ComponentModel.DataAnnotations;

namespace StreamWorker.ViewModels.Account
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Telefonnummer")]
        public string Number { get; set; }
    }
}