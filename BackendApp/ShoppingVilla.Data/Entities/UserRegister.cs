using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities
{
    public class UserRegister
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key()]
        public int Id { get; set; }
        [MinLength(5)]
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [MinLength(5)]
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        public string? ConfirmPassword { get; set; }

    }
}
