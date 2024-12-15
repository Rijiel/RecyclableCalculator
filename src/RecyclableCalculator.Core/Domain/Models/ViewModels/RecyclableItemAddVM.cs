using RecyclableCalculator.Core.Dto.RecyclableItemDtos;
using RecyclableCalculator.Core.Dto.RecyclableTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecyclableCalculator.Core.Domain.Models.ViewModels
{
	public class RecyclableItemAddVM
	{
		public RecyclableItemAddRequest RecyclableItemAddRequest { get; set; }
		public IEnumerable<RecyclableTypeResponse> RecyclableTypes { get; set; }
	}
}
