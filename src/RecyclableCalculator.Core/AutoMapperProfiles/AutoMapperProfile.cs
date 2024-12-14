using AutoMapper;
using RecyclableCalculator.Core.Domain.Models;
using RecyclableCalculator.Core.Dto.RecyclableItemDtos;
using RecyclableCalculator.Core.Dto.RecyclableTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.AutoMapperProfiles
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			// RecyclableType
			CreateMap<RecyclableType, RecyclableTypeResponse>();
			CreateMap<RecyclableTypeAddRequest, RecyclableType>();
			CreateMap<RecyclableTypeResponse, RecyclableTypeUpdateRequest>();
			CreateMap<RecyclableTypeUpdateRequest, RecyclableType>();

			// RecyclableItem
			CreateMap<RecyclableItem, RecyclableItemResponse>();
			CreateMap<RecyclableItemAddRequest, RecyclableItem>();
			CreateMap<RecyclableItemResponse, RecyclableItemUpdateRequest>();
			CreateMap<RecyclableItemUpdateRequest, RecyclableItem>();
		}
	}
}
