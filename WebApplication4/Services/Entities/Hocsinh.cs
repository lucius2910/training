﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Services.Entities
{
	public class Hocsinh
	{
		[Key]
		public int Id { get; set; }

		[Column(TypeName = "nvarchar")]
		[MaxLength(100)]
		public string Ma { get; set; }

		[Column(TypeName = "nvarchar")]
		[MaxLength(100)]
		public string Ten { get; set; }

		public int LopId { get; set; }

		public DateTime NgaySinh { get; set; }

	}
}
