using AutoMapper;
using RecyclableCalculator.Core.AutoMapperProfiles;
using RecyclableCalculator.Core.Domain.Models.ViewModels;
using RecyclableCalculator.Core.Dto.RecyclableItemDtos;
using RecyclableCalculator.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RecyclableCalculator.Web.Controllers
{
	public class RecyclableItemsController : Controller
	{
		private readonly IRecyclableItemService _itemService;
		private readonly IRecyclableTypeService _typeService;
		private readonly IMapper _mapper;

		public RecyclableItemsController(IRecyclableItemService itemService, IRecyclableTypeService typeService)
		{
			_mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();
			_itemService = itemService;
			_typeService = typeService;
		}

		public async Task<ActionResult> Index()
		{
			List<RecyclableItemResponse> recyclableItems = await _itemService.GetAllAsync();

			return View(recyclableItems);
		}

		[HttpGet]
		public async Task<ActionResult> Create()
		{
			var recyclableTypes = await _typeService.GetAllAsync();

			var recyclableItemAddVM = new RecyclableItemAddVM()
			{
				RecyclableItemAddRequest = new RecyclableItemAddRequest(),
				RecyclableTypes = await _typeService.GetAllAsync()
			};

			return View(recyclableItemAddVM);
		}
	}
}