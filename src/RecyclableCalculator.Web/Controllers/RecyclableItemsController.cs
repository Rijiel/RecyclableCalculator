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
			// Initialize RecyclableItemAddVM
			var recyclableItemAddVM = new RecyclableItemAddVM()
			{
				RecyclableItemAddRequest = new RecyclableItemAddRequest(),
				RecyclableTypes = await _typeService.GetAllAsync()
			};

			return View(recyclableItemAddVM);
		}

		[HttpPost]
		public async Task<ActionResult> Create(RecyclableItemAddVM requestVM)
		{
			if (ModelState.IsValid)
			{
				await _itemService.AddAsync(requestVM.RecyclableItemAddRequest);

				return RedirectToAction("Index");
			}

			// If we get here, something went wrong, re-render the form
			requestVM.RecyclableTypes = await _typeService.GetAllAsync();

			return View(requestVM);
		}

		[HttpGet]
		public async Task<ActionResult> Edit(int? id)
		{
			RecyclableItemResponse recyclableItem = await _itemService.GetByIdAsync(id);
			if (recyclableItem == null)
			{
				return HttpNotFound("Recyclable item not found");
			}

			// Initialize RecyclableItemUpdateVM
			var recyclableItemUpdateVM = new RecyclableItemUpdateVM()
			{
				RecyclableItemUpdateRequest = _mapper.Map<RecyclableItemUpdateRequest>(recyclableItem),
				RecyclableTypes = await _typeService.GetAllAsync()
			};

			return View(recyclableItemUpdateVM);
		}

		[HttpPost]
		public async Task<ActionResult> Edit(RecyclableItemUpdateVM requestVM)
		{
			if (ModelState.IsValid)
			{
				await _itemService.UpdateAsync(requestVM.RecyclableItemUpdateRequest);

				return RedirectToAction("Index");
			}

			// If we get here, something went wrong, re-render the form
			requestVM.RecyclableTypes = await _typeService.GetAllAsync();

			return View(requestVM);
		}

		[HttpGet]
		public async Task<ActionResult> Delete(int? id)
		{
			RecyclableItemResponse recyclableItem = await _itemService.GetByIdAsync(id);
			if (recyclableItem == null)
			{
				return HttpNotFound("Recyclable item not found");
			}

			return View(recyclableItem);
		}

		[HttpPost]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				await _itemService.RemoveAsync(id);

				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				return View("Error");
			}
		}
	}
}