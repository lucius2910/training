using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Services.Entires
{
	public class Lop
	{
		[Key]
		public int Id { get; set; }

		[Column(TypeName = "nvarchar")]
		[MaxLength(100)]
		public string MaLop { get; set; }

		[Column(TypeName = "nvarchar")]
		[MaxLength(100)]
		public string Ten { get; set; }
		
	}
}
