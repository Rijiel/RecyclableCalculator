﻿using RecyclableCalculator.Core.Domain.Models;
using RecyclableCalculator.Core.Dto.RecyclableTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.ServiceContracts
{
	public interface IRecyclableTypeService : IGenericService<RecyclableType, RecyclableTypeAddRequest,
		RecyclableTypeUpdateRequest, RecyclableTypeResponse>
	{
	}
}