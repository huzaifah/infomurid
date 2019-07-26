using System.ComponentModel.DataAnnotations;

namespace DMHTechnology.InfoMurid.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}