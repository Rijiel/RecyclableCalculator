using AutoMapper;
using RecyclableCalculator.Core.AutoMapperProfiles;
using RecyclableCalculator.Core.Dto.RecyclableTypeDtos;
using RecyclableCalculator.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RecyclableCalculator.Web.Controllers
{
	public class RecyclableTypesController : Controller
	{
		private readonly IRecyclableTypeService _typeService;
		private readonly IMapper _mapper;

		public RecyclableTypesController(IRecyclableTypeService typeService)
		{
			_mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();
			_typeService = typeService;
		}

		public async Task<ActionResult> Index()
		{
			List<RecyclableTypeResponse> recyclableTypes = await _typeService.GetAllAsync();

			return View(recyclableTypes);
		}

		[HttpGet]
		public ActionResult Create() => View();

		[HttpPost]
		public async Task<ActionResult> Create(RecyclableTypeAddRequest request)
		{
			if (ModelState.IsValid)
			{
				// Check if the type already exists
				if (await TypeExistsAsync(request.Type))
				{
					ModelState.AddModelError(nameof(request.Type), "Type already exists");
					return View();
				}

				await _typeService.AddAsync(request);

				return RedirectToAction("Index");
			}

			// If we get here, something went wrong, re-render the form
			return View(request);
		}

		[HttpGet]
		public async Task<ActionResult> Edit(int? id)
		{
			RecyclableTypeResponse recyclableType = await _typeService.GetByIdAsync(id);
			if (recyclableType == null)
			{
				return HttpNotFound("Recyclable type not found");
			}

			return View(_mapper.Map<RecyclableTypeUpdateRequest>(recyclableType));
		}

		[HttpPost]
		public async Task<ActionResult> Edit(RecyclableTypeUpdateRequest request)
		{
			if (ModelState.IsValid)
			{
				// Check if the type already exists if current type is changed
				RecyclableTypeResponse recyclableType = await _typeService.GetByIdAsync(request.Id);
				if (recyclableType.Type != request.Type && await TypeExistsAsync(request.Type))
				{
					ModelState.AddModelError(nameof(request.Type), "Type already exists");
					return View();
				}

				await _typeService.UpdateAsync(request);

				return RedirectToAction("Index");
			}

			// If we get here, something went wrong, re-render the form
			return View(request);
		}

		[HttpGet]
		public async Task<ActionResult> Delete(int? id)
		{
			RecyclableTypeResponse recyclableType = await _typeService.GetByIdAsync(id);
			if (recyclableType == null)
			{
				return HttpNotFound("Recyclable type not found");
			}

			return View(recyclableType);
		}

		[HttpPost]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				await _typeService.RemoveAsync(id);

				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				return View("Error");
			}
		}

		private async Task<bool> TypeExistsAsync(string typeName)
			=> await _typeService.GetAsync(rt => rt.Type == typeName) != null;
	}
}