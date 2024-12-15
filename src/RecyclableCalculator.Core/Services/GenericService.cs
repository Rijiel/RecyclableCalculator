using AutoMapper;
using RecyclableCalculator.Core.AutoMapperProfiles;
using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Core.Services
{
	public class GenericService<TModel, TAddDto, TUpdateDto, TResponseDto>
		: IGenericService<TModel, TAddDto, TUpdateDto, TResponseDto>
		where TModel : class
		where TAddDto : class
		where TUpdateDto : class
		where TResponseDto : class
	{
		private readonly IGenericRepository<TModel> _repository;
		private readonly IMapper _mapper;

		public GenericService(IGenericRepository<TModel> repository)
		{
			_repository = repository;
			_mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();
		}

		protected IMapper Mapper => _mapper;

		public async Task<List<TResponseDto>> GetAllAsync(Expression<Func<TModel, bool>> filter = null, params string[] includes)
		{
			IEnumerable<TModel> models = await _repository.GetAllAsync(filter, includes);
			return _mapper.Map<List<TResponseDto>>(models);
		}

		public async Task<TResponseDto> GetAsync(Expression<Func<TModel, bool>> filter, bool asNoTracking = true, params string[] includes)
		{
			TModel model = await _repository.GetAsync(filter, asNoTracking, includes);
			return _mapper.Map<TResponseDto>(model);
		}

		public async Task<TResponseDto> GetByIdAsync(int? id, bool asNoTracking = true, params string[] includes)
		{
			if (id == null)
			{
				return null;
			}

			TModel model = await _repository.GetByIdAsync(id.Value, asNoTracking, includes);
			return _mapper.Map<TResponseDto>(model);
		}

		public async Task<TResponseDto> AddAsync(TAddDto addDto)
		{
			if (addDto == null)
			{
				throw new ArgumentNullException(nameof(addDto));
			}

			TModel model = _mapper.Map<TModel>(addDto);

			_repository.Add(model);
			await _repository.SaveChangesAsync();

			return _mapper.Map<TResponseDto>(model);
		}

		public async Task<TResponseDto> UpdateAsync(TUpdateDto updateDto)
		{
			if (updateDto == null)
			{
				throw new ArgumentNullException(nameof(updateDto));
			}

			// Use reflection to get the property "Id" from the generic type
			var id = typeof(TUpdateDto).GetProperty("Id").GetValue(updateDto);
			if (id == null)
			{
				throw new KeyNotFoundException($"{nameof(TModel)} does not contain {nameof(id)}");
			}

			// Update the model by mapping the updateDto to the data from db
			TModel model = await _repository.GetByIdAsync((int)id, false);
			_mapper.Map(updateDto, model);

			await _repository.SaveChangesAsync();
			
			return _mapper.Map<TResponseDto>(model);
		}

		public async Task RemoveAsync(int id)
		{
			TModel model = await _repository.GetByIdAsync(id) 
				?? throw new KeyNotFoundException($"{nameof(TModel)} with {nameof(id)} {id} not found");

			_repository.Remove(model);
			await _repository.SaveChangesAsync();
		}
	}
}
