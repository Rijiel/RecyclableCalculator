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
		/// <summary>
		/// Computes the rate for the given recyclable item asynchronously.
		/// </summary>
		/// <param name="recyclableItem">The recyclable item to compute the rate for.</param>
		/// <returns>The task that returns the computed rate for the recyclable item.</returns>
		Task<double> GetComputedRateAsync(RecyclableItem recyclableItem);
	}
}
