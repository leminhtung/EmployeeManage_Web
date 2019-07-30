using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class mvcEmployeeModel
    {
        public int UserId { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "username is too long")]
        [Required(ErrorMessage = "username can not be blank")]
        public string Username { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "PhoneNumber can not be blank")]
        [RegularExpression(@"^[0-9]{9,10}$", ErrorMessage = "Phone number wrong format")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email can not be blank")]
        public string Email { get; set; }
    }
}