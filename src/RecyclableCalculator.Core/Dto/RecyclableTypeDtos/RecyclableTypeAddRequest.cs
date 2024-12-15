using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Dto.RecyclableTypeDtos
{
	public class RecyclableTypeAddRequest
	{
		[Required]
		[StringLength(100)]
		public string Type { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		[Range(0, int.MaxValue)]
		public decimal Rate { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		[Range(0, int.MaxValue)]
		public decimal MinKg { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		[Range(0, int.MaxValue)]
		public decimal MaxKg { get; set; }
	}
}
