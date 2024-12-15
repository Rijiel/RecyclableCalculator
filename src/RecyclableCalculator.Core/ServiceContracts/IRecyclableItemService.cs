using RecyclableCalculator.Core.Domain.Models;
using RecyclableCalculator.Core.Dto.RecyclableItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.ServiceContracts
{
	public interface IRecyclableItemService : IGenericService<RecyclableItem, RecyclableItemAddRequest,
		RecyclableItemUpdateRequest, RecyclableItemResponse>
	{
	}
}
