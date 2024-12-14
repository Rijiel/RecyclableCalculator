using RecyclableCalculator.Core.Domain.Models.Validations;
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
		public double Rate { get; set; }
		public double MinKg { get; set; }
		public double MaxKg { get; set; }
	}
}
