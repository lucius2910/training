using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Services.Entities
{
	public class Vehicle
	{
		[Key]
		public int? Id { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public string Name { get; set; }
		public DateTime? ExpriedDate { get; set; }

		public User? User { get; set; }

	}

}
