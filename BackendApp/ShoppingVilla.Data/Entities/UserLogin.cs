using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShoppingVilla.Data.Entities
{
    public class UserLogin
    {
        private DateTime _currentDt = DateTime.Now;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="User Name is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; set; }
        public string? Token { get; set; }
        [ForeignKey("UserRegister")]
        public int UserId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public UserRegister? UserRegister { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
    }
}
