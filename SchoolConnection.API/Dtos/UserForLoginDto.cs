using System.ComponentModel.DataAnnotations;

namespace SchoolConnection.API.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}