using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Entires
{
	public class Giaovien
	{
		[Key]
		public int Id { get; set; }

		[Column(TypeName = "nvarchar")]
		[MaxLength(100)]
		public string Ma { get; set; }

		[Column(TypeName = "nvarchar")]
		[MaxLength(100)]
		public string Ten { get; set; }

        [ForeignKey("Lop")]
        public int LopId { get; set; }

        public Lop Lop { get; set; }
    }
}									
