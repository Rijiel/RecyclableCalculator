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

		public string Type { get; set; }

		public decimal Rate { get; set; }

		public decimal MinKg { get; set; }

		public decimal MaxKg { get; set; }
	}
}
