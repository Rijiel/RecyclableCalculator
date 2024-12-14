using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Domain.Models
{
	public class RecyclableType
	{
		public int Id { get; set; }

		[Column(TypeName = "varchar(100)")]
		public string Type { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public double Rate { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public double MinKg { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public double MaxKg { get; set; }
	}
}
