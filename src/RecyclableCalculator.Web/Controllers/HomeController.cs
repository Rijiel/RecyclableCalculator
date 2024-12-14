using RecyclableCalculator.Core.Domain.RepositoryContracts;
using RecyclableCalculator.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecyclableCalculator.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRecyclableItemRepository recyclableItemRepository;

		public HomeController(IRecyclableItemRepository recyclableItemRepository)
		{
			this.recyclableItemRepository = recyclableItemRepository;
		}

		public ActionResult Index()
		{
			return View();
		}
	}
}