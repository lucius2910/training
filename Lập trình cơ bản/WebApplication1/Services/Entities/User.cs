using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Services.Utils;

namespace Services.Entities
{
    public class User
    {
        [Key]
        public int? Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Vehicle>? Vehicles { get; set; }   
       
    }
}
