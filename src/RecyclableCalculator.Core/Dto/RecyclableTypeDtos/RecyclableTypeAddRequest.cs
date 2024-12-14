using RecyclableCalculator.Core.Domain.Models.Validations;
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
		[UniqueType]
		public string Type { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		public double Rate { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		public double MinKg { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		public double MaxKg { get; set; }
	}
}
