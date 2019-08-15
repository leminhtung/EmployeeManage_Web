using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int UserId { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "characters between 3 and 50")]
        [Required(ErrorMessage = "username can not be blank")]
        public string Username { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "PhoneNumber can not be blank")]
        [RegularExpression(@"^(09|08[3|6|8|9])+([0-9]{7})$", ErrorMessage = "Phone number wrong format")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        //[A-Z0-9._%+-]+@[A-Z0-9-]+.+.[A-Z]{2,4}
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email can not be blank")]
        public string Email { get; set; }
    }
}