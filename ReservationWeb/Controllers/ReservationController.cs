using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReservationAPI.Models;
using System.Net.Http;

namespace ReservationWeb.Controllers
{
	public class ReservationController : Controller
	{
		private readonly HttpClient _httpClient;

		public ReservationController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
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

		public async Task<IActionResult> Update()
		{
			return View();
		}
	}
}
