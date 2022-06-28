using System.ComponentModel.DataAnnotations;

namespace BlogWebApi.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "O slug é obrigatório.")]
        public string? Slug { get; set; }
    }
}
