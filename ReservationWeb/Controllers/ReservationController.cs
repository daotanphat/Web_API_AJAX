using Microsoft.AspNetCore.Mvc;

namespace ReservationWeb.Controllers
{
	public class ReservationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetById()
		{
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}
	}
}
