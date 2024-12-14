using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Dto.RecyclableItemDtos
{
	public class RecyclableItemResponse
	{
		public int Id { get; set; }
		public string ItemDescription { get; set; }
		public int RecyclableTypeId { get; set; }
		public double Weight { get; set; }
		public double ComputedRate { get; set; }
	}
}
