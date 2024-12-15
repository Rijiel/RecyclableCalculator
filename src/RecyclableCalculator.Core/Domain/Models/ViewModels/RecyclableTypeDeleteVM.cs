using RecyclableCalculator.Core.Dto.RecyclableTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Domain.Models.ViewModels
{
	public class RecyclableTypeDeleteVM
	{
		public RecyclableTypeResponse RecyclableTypeResponse { get; set; }
		public bool IsDeletable { get; set; }
	}
}
