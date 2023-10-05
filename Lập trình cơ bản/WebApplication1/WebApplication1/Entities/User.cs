using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Utils;

namespace WebApplication1.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }   
       
    }
}
