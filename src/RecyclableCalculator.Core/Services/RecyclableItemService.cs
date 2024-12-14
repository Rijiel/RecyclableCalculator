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
		private readonly IRecyclableTypeRepository _recyclableTypeRepository;

		public RecyclableItemService(IRecyclableItemRepository repository, 
			IRecyclableTypeRepository recyclableTypeRepository) : base(repository)
		{
			_recyclableTypeRepository = recyclableTypeRepository;
		}

		public async Task<double> GetComputedRateAsync(RecyclableItem recyclableItem)
		{
			if (recyclableItem == null)
			{
				throw new ArgumentNullException(nameof(recyclableItem));
			}

			// Get RecyclableType from repository by RecyclableTypeId, throw exception if not found
			RecyclableType recyclableType = await _recyclableTypeRepository.GetByIdAsync(recyclableItem.RecyclableTypeId) 
				?? throw new KeyNotFoundException($"{nameof(RecyclableType)} with " +
					$"{nameof(recyclableItem.RecyclableTypeId)} {recyclableItem.RecyclableTypeId} not found");

			// Get computed rate by multiplying RecyclableType rate by RecyclableItem weight and rounding to 2 decimal places
			return Math.Round(recyclableType.Rate * recyclableItem.Weight, 2);
		}
	}
}
