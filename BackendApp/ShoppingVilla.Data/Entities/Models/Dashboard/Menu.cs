using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShoppingVilla.Data.Entities.Models.Dashboard
{
    public class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public virtual Module? Module { get; set; }

    }
}
