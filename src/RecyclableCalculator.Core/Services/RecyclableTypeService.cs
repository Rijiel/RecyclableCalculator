using AutoMapper;
using RecyclableCalculator.Core.Domain.Models;
using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Core.Dto.RecyclableTypeDtos;
using RecyclableCalculator.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Services
{
	public class RecyclableTypeService : GenericService<RecyclableType, RecyclableTypeAddRequest, 
		RecyclableTypeUpdateRequest, RecyclableTypeResponse>, IRecyclableTypeService
	{
		public RecyclableTypeService(IRecyclableTypeRepository repository, IMapper mapper) : base(repository, mapper)
		{			
		}
	}
}
