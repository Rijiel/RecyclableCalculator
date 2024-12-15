using RecyclableCalculator.Core.Dto.RecyclableItemDtos;
using RecyclableCalculator.Core.Dto.RecyclableTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Domain.Models.ViewModels
{
	public class RecyclableItemUpdateVM
	{
		public RecyclableItemUpdateRequest RecyclableItemUpdateRequest { get; set; }
		public IEnumerable<RecyclableTypeResponse> RecyclableTypes { get; set; }
	}
}
