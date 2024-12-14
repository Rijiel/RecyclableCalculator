using RecyclableCalculator.Core.Domain.Models;
using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Infrastructure.Repositories
{
	public class RecyclableTypeRepository : GenericRepository<RecyclableType>, IRecyclableTypeRepository
	{
		public RecyclableTypeRepository(ApplicationDbContext context) : base(context)
		{			
		}
	}
}
