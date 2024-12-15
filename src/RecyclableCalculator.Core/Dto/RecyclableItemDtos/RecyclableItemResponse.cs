using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Dto.RecyclableItemDtos
{
	public class RecyclableItemResponse
	{
		public int Id { get; set; }

		[DisplayName("Item Description")]
		public string ItemDescription { get; set; }

		[DisplayName("Recyclable Type")]
		public int RecyclableTypeId { get; set; }

		public double Weight { get; set; }

		[DisplayName("Computed Rate")]
		public double ComputedRate { get; set; }
	}
}
