using AutoMapper;
using FluentAssertions;
using Moq;
using RecyclableCalculator.Core.AutoMapperProfiles;
using RecyclableCalculator.Core.Domain.Models;
using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Core.Dto.RecyclableTypeDtos;
using RecyclableCalculator.Core.ServiceContracts;
using RecyclableCalculator.Core.Services;
using System.Linq.Expressions;

namespace RecyclableCalculator.ServiceTests
{
	public class RecyclableTypeServiceTest
	{
		private readonly IMapper _mapper;
		private readonly Mock<IRecyclableTypeRepository> _recyclableTypeRepositoryMock;

		private readonly IRecyclableTypeRepository _recyclableTypeRepository;
		private readonly IRecyclableTypeService _recyclableTypeService;

		public RecyclableTypeServiceTest()
		{
			_mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();

			_recyclableTypeRepositoryMock = new Mock<IRecyclableTypeRepository>();
			_recyclableTypeRepository = _recyclableTypeRepositoryMock.Object;
			_recyclableTypeService = new RecyclableTypeService(_recyclableTypeRepository);
		}

		#region GetAllAsync
		[Fact]
		public async Task GetAllAsync_ShouldReturnEmptyByDefault()
		{
			// Arrange
			var recyclableTypes = new List<RecyclableType>();
			_recyclableTypeRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<RecyclableType, bool>>>()))
				.ReturnsAsync(recyclableTypes);

			// Act
			List<RecyclableTypeResponse> result = await _recyclableTypeService.GetAllAsync();

			// Assert
			result.Should().BeEmpty();
		}

		[Fact]
		public async Task GetAllAsync_GivenRecyclableTypes_ShouldReturnRecyclableTypes()
		{
			// Arrange
			var recyclableTypes = new List<RecyclableType>()
			{
				new() {
					Id = 1,
					Type = "Plastic",
					Rate = (decimal)(decimal)0.5,
					MinKg = (decimal)(decimal)0.5,
					MaxKg = (decimal)1.0
				},
				new()
				{
					Id = 2,
					Type = "Glass",
					Rate = (decimal)0.5,
					MinKg = (decimal)0.5,
					MaxKg = (decimal) 1.0
				}
			};

			var expected = _mapper.Map<List<RecyclableTypeResponse>>(recyclableTypes);

			_recyclableTypeRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<RecyclableType, bool>>>()))
				.ReturnsAsync(recyclableTypes);

			// Act
			List<RecyclableTypeResponse> result = await _recyclableTypeService.GetAllAsync();

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[Fact]
		public async Task GetAllAsync_GivenFilter_ShouldReturnFilteredRecyclableTypes()
		{
			// Arrange
			var recyclableTypes = new List<RecyclableType>()
			{
				new() {
					Id = 1,
					Type = "Plastic",
					Rate = (decimal)0.5,
					MinKg = (decimal)0.5,
					MaxKg = (decimal) 1.0
				},
				new()
				{
					Id = 2,
					Type = "Glass",
					Rate = (decimal)0.5,
					MinKg = (decimal)0.5,
					MaxKg = (decimal) 1.0
				}
			};

			Expression<Func<RecyclableType, bool>> filter = x => x.Type == "Plastic";
			recyclableTypes = recyclableTypes.Where(filter.Compile()).ToList();
			var expected = _mapper.Map<List<RecyclableTypeResponse>>(recyclableTypes);

			_recyclableTypeRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<RecyclableType, bool>>>()))
				.ReturnsAsync(recyclableTypes);

			// Act
			List<RecyclableTypeResponse> result = await _recyclableTypeService.GetAllAsync();

			// Assert
			result.Should().BeEquivalentTo(expected);
		}
		#endregion

		#region GetAsync
		[Fact]
		public async Task GetAsync_GivenFilterWithNoResult_ShouldReturnNull()
		{
			// Arrange
			RecyclableType recyclableType = null;
			Expression<Func<RecyclableType, bool>> filter = x => x.Type == "Plastic";

			_recyclableTypeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Expression<Func<RecyclableType, bool>>>(),
				It.IsAny<bool>())).ReturnsAsync(recyclableType);

			// Act
			RecyclableTypeResponse result = await _recyclableTypeService.GetAsync(filter);

			// Assert
			result.Should().BeNull();
		}

		[Fact]
		public async Task GetAsync_GivenFilterWithResult_ShouldReturnRecyclableType()
		{
			// Arrange
			var recyclableType = new RecyclableType()
			{
				Id = 1,
				Type = "Plastic",
				Rate = (decimal)0.5,
				MinKg = (decimal)0.5,
				MaxKg = (decimal)1.0
			};

			Expression<Func<RecyclableType, bool>> filter = x => x.Type == "Plastic";

			var expected = _mapper.Map<RecyclableTypeResponse>(recyclableType);

			_recyclableTypeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Expression<Func<RecyclableType, bool>>>(),
				It.IsAny<bool>())).ReturnsAsync(recyclableType);

			// Act
			RecyclableTypeResponse result = await _recyclableTypeService.GetAsync(filter);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}
		#endregion

		#region GetByIdAsync
		[Fact]
		public async Task GetByIdAsync_GivenNullId_ShouldReturnNull()
		{
			// Arrange
			RecyclableType recyclableType = null;
			int? id = null;

			_recyclableTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
				.ReturnsAsync(recyclableType);

			// Act
			RecyclableTypeResponse result = await _recyclableTypeService.GetByIdAsync(id);

			// Assert
			result.Should().BeNull();
		}

		[Fact]
		public async Task GetByIdAsync_GivenInvalidId_ShouldReturnNull()
		{
			// Arrange
			RecyclableType recyclableType = null;
			int? id = 0;

			_recyclableTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
				.ReturnsAsync(recyclableType);

			// Act
			RecyclableTypeResponse result = await _recyclableTypeService.GetByIdAsync(id);

			// Assert
			result.Should().BeNull();
		}

		[Fact]
		public async Task GetByIdAsync_GivenValidId_ShouldReturnRecyclableType()
		{
			// Arrange
			var recyclableType = new RecyclableType()
			{
				Id = 1,
				Type = "Plastic",
				Rate = (decimal)0.5,
				MinKg = (decimal)0.5,
				MaxKg = (decimal)1.0
			};

			int id = 1;
			var expected = _mapper.Map<RecyclableTypeResponse>(recyclableType);

			_recyclableTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
				.ReturnsAsync(recyclableType);

			// Act
			RecyclableTypeResponse result = await _recyclableTypeService.GetByIdAsync(id);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}
		#endregion

		#region AddAsync
		[Fact]
		public async Task AddAsync_GivenNullRecyclableType_ShouldThrowArgumentNullException()
		{
			// Arrange
			RecyclableTypeAddRequest request = null;

			_recyclableTypeRepositoryMock.Setup(x => x.Add(It.IsAny<RecyclableType>()));

			// Act
			Func<Task> result = async () => await _recyclableTypeService.AddAsync(request);

			// Assert
			await result.Should().ThrowAsync<ArgumentNullException>();
		}

		[Fact]
		public async Task AddAsync_GivenRecyclableType_ShouldReturnRecyclableTypeResponse()
		{
			// Arrange
			var request = new RecyclableTypeAddRequest()
			{
				Type = "Plastic",
				Rate = (decimal)0.5,
				MinKg = (decimal)0.5,
				MaxKg = (decimal)1.0
			};

			var recyclableType = _mapper.Map<RecyclableType>(request);
			var expected = _mapper.Map<RecyclableTypeResponse>(recyclableType);

			_recyclableTypeRepositoryMock.Setup(x => x.Add(It.IsAny<RecyclableType>()));

			// Act
			var result = await _recyclableTypeService.AddAsync(request);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}
		#endregion

		#region UpdateAsync
		[Fact]
		public async Task UpdateAsync_GivenNullRecyclableType_ShouldThrowArgumentNullException()
		{
			// Arrange
			RecyclableTypeUpdateRequest request = null;

			// Act
			Func<Task> result = async () => await _recyclableTypeService.UpdateAsync(request);

			// Assert
			await result.Should().ThrowAsync<ArgumentNullException>();
		}

		[Fact]
		public async Task UpdateAsync_GivenRecyclableType_ShouldReturnRecyclableTypeResponse()
		{
			// Arrange
			var request = new RecyclableTypeUpdateRequest()
			{
				Id = 1,
				Type = "Plastic",
				Rate = (decimal)0.5,
				MinKg = (decimal)0.5,
				MaxKg = (decimal)1.0
			};

			var recyclableType = _mapper.Map<RecyclableType>(request);
			var expected = _mapper.Map<RecyclableTypeResponse>(recyclableType);

			_recyclableTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
				.ReturnsAsync(recyclableType);

			// Act
			RecyclableTypeResponse result = await _recyclableTypeService.UpdateAsync(request);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}
		#endregion

		#region RemoveAsync
		[Fact]
		public async Task RemoveAsync_GivenInvalidId_ShouldThrowKeyNotFoundException()
		{
			// Arrange
			int id = 0;

			_recyclableTypeRepositoryMock.Setup(x => x.Remove(It.IsAny<RecyclableType>()));

			// Act
			Func<Task> result = async () => await _recyclableTypeService.RemoveAsync(id);

			// Assert
			await result.Should().ThrowAsync<KeyNotFoundException>();
		}

		[Fact]
		public async Task RemoveAsync_GivenValidId_ShouldCallRemove()
		{
			// Arrange
			int id = 1;
			var recyclableType = new RecyclableType()
			{
				Id = id,
				Type = "Plastic",
				Rate = (decimal)0.5,
				MinKg = (decimal)0.5,
				MaxKg = (decimal)1.0
			};

			_recyclableTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
				.ReturnsAsync(recyclableType);

			_recyclableTypeRepositoryMock.Setup(x => x.Remove(It.IsAny<RecyclableType>()));

			// Act
			await _recyclableTypeService.RemoveAsync(id);

			// Assert
			_recyclableTypeRepositoryMock.Verify(x => x.Remove(It.IsAny<RecyclableType>()), Times.Once);
		}
		#endregion
	}
}