using RecyclableCalculator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Dto.RecyclableItemDtos
{
	public class RecyclableItemAddRequest
	{
		[StringLength(150)]
		[DisplayName("Item Description")]
		public string ItemDescription { get; set; }

		[Required]
		[DisplayName("Recyclable Type")]
		public int RecyclableTypeId { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		[Range(0, int.MaxValue)]
		public double Weight { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
		[Range(0, int.MaxValue)]
		[DisplayName("Computed Rate")]
		public double ComputedRate { get; set; }
	}
}
