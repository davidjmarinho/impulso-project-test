using System.ComponentModel.DataAnnotations;

namespace ImpulsoProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}