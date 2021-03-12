using System.ComponentModel.DataAnnotations;

namespace DemoTask.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}