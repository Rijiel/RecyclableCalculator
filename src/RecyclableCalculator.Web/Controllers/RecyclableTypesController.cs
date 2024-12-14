using AutoMapper;
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

		public RecyclableTypesController(IRecyclableTypeService typeService)
		{
			_typeService = typeService;
		}

		public async Task<ActionResult> Index()
        {
			List<RecyclableTypeResponse> recyclableTypes = await _typeService.GetAllAsync();

			return View(recyclableTypes);
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Create(RecyclableTypeAddRequest request)
		{
			if (ModelState.IsValid && !TypeExists(request.Type))
			{
				await _typeService.AddAsync(request);

				return RedirectToAction("Index");
			}

			return View();
		}

		private bool TypeExists(string typeName) => _typeService.GetAsync(rt => rt.Type == typeName) != null;
	}
}