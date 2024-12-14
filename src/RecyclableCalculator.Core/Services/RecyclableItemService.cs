using AutoMapper;
using RecyclableCalculator.Core.Domain.Models;
using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Core.Dto.RecyclableItemDtos;
using RecyclableCalculator.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Services
{
	public class RecyclableItemService : GenericService<RecyclableItem, RecyclableItemAddRequest,
		RecyclableItemUpdateRequest, RecyclableItemResponse>, IRecyclableItemService
	{
		public RecyclableItemService(IRecyclableItemRepository repository, IMapper mapper) : base(repository, mapper)
		{			
		}
	}
}
