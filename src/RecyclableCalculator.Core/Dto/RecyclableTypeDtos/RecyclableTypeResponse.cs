using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Dto.RecyclableTypeDtos
{
	public class RecyclableTypeResponse
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public decimal Rate { get; set; }
		public decimal MinKg { get; set; }
		public decimal MaxKg { get; set; }
	}
}
