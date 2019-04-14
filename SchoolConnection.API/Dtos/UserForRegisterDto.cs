using System.ComponentModel.DataAnnotations;

namespace SchoolConnection.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}