using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Dto.RecyclableItemDtos
{
	public class RecyclableItemUpdateRequest
	{
		[Required]
		public int Id { get; set; }

		[StringLength(150)]
		public string ItemDescription { get; set; }

		[Required]
		public int RecyclableTypeId { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		public double Weight { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		public double ComputedRate { get; set; }
	}
}
