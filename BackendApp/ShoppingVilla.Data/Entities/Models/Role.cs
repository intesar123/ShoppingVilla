using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShoppingVilla.Data.Entities.Models
{
    public class Role
    {
        private string _Name = string.Empty;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = string.IsNullOrEmpty(value) ? string.Empty : value.ToUpper();
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public virtual UserRegister? UserRegister { get; set; }
    }
}
