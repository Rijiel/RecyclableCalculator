using AutoMapper;
using FluentAssertions;
using Moq;
using RecyclableCalculator.Core.AutoMapperProfiles;
using RecyclableCalculator.Core.Domain.Models;
using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Core.ServiceContracts;
using RecyclableCalculator.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.ServiceTests;

public class RecyclableItemServiceTest
{
	private readonly IMapper _mapper;
	private readonly Mock<IRecyclableItemRepository> _recyclableItemRepositoryMock;
	private readonly Mock<IRecyclableTypeRepository> _recyclableTypeRepositoryMock;

	private readonly IRecyclableItemRepository _recyclableItemRepository;
	private readonly IRecyclableTypeRepository _recyclableTypeRepository;
	private readonly IRecyclableItemService _recyclableItemService;

	public RecyclableItemServiceTest()
	{
		_mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();

		_recyclableItemRepositoryMock = new Mock<IRecyclableItemRepository>();
		_recyclableItemRepository = _recyclableItemRepositoryMock.Object;

		_recyclableTypeRepositoryMock = new Mock<IRecyclableTypeRepository>();
		_recyclableTypeRepository = _recyclableTypeRepositoryMock.Object;

		_recyclableItemService = new RecyclableItemService(_recyclableItemRepository, _recyclableTypeRepository, _mapper);
	}

	[Fact]
	public async Task GetComputedRateAsync_GivenNullRecyclableItem_ShouldThrowArgumentNullException()
	{
		// Arrange
		RecyclableItem recyclableItem = null;

		// Act
		Func<Task> result = async () => await _recyclableItemService.GetComputedRateAsync(recyclableItem);

		// Assert
		await result.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetComputedRateAsync_GivenInvalidTypeId_ShouldThrowKeyNotFoundException()
	{
		// Arrange
		var recyclableItem = new RecyclableItem()
		{
			Id = 1,
			ItemDescription = "Test Item",
			RecyclableTypeId = 0,
			Weight = 1,
			ComputedRate = 1
		};

		_recyclableTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
			.ReturnsAsync((RecyclableType)null);

		// Act
		Func<Task> result = async () => await _recyclableItemService.GetComputedRateAsync(recyclableItem);

		// Assert
		await result.Should().ThrowAsync<KeyNotFoundException>();
	}

	[Theory]
	[InlineData(1, 0.5)]
	[InlineData(0.5, 1)]
	[InlineData(25.60, 0.75)]
	[InlineData(111, 50.89)]
	[InlineData(507.89, 8)]
	public async Task GetComputedRateAsync_ValidRecyclableItem_ShouldReturnFormattedComputedRate(double weight, double rate)
	{
		// Arrange
		var recyclableItem = new RecyclableItem()
		{
			Id = 1,
			ItemDescription = "Test Item",
			RecyclableTypeId = 1,
			Weight = weight,
			ComputedRate = 1
		};

		var recyclableType = new RecyclableType()
		{
			Id = 1,
			Type = "Plastic",
			Rate = rate,
			MinKg = 0.5,
			MaxKg = 1.0
		};

		_recyclableTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
			.ReturnsAsync(recyclableType);

		double expected = Math.Round(recyclableType.Rate * recyclableItem.Weight, 2);

		// Act
		double result = await _recyclableItemService.GetComputedRateAsync(recyclableItem);

		// Assert
		result.Should().Be(expected);
	}
}
