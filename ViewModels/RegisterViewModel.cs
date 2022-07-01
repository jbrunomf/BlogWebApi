using System.ComponentModel.DataAnnotations;

namespace BlogWebApi.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O E-mail é inválido.")]
        public string Email { get; set; }
    }
}
