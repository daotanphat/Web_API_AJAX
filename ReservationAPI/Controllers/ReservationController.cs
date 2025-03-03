using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using ReservationAPI.Models;
using ReservationAPI.Repository;
using System.Xml.Linq;

namespace ReservationAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationController : ControllerBase
	{
		private IReservationRepository _repo;
		private IWebHostEnvironment _webHostEnvironment;
		public ReservationController(IReservationRepository repo, IWebHostEnvironment webHostEnvironment)
		{
			_repo = repo;
			_webHostEnvironment = webHostEnvironment;
		}

		[HttpGet]
		public IEnumerable<Reservation> Get() => _repo.Reservations;

		[HttpGet("{id}")]
		public ActionResult<Reservation> Get([FromRoute] int id)
		{
			if (id == 0) return BadRequest("Value must be passed in the request body.");
			return Ok(_repo[id]);
		}

		[HttpPost]
		public Reservation Post([FromBody] Reservation reservation)
		{
			return _repo.AddReservation(new Reservation
			{
				Name = reservation.Name,
				StartLocation = reservation.StartLocation,
				EndLocation = reservation.EndLocation
			});
		}

		[HttpPut]
		public Reservation Put([FromForm] Reservation reservation)
		{
			return _repo.UpdateReservation(reservation);
		}

		[HttpDelete("{id}")]
		public void Delete([FromRoute] int id) => _repo.DeleteReservation(id);

		bool Authenticate()
		{
			var allowedKeys = new[] { "Secret@123", "Secret#12", "SecretABC" };
			StringValues key = Request.Headers["Key"];
			int count = (from t in allowedKeys where t == key select t).Count();
			return count == 0 ? false : true;
		}

		[HttpPost("PostXml")]
		[Consumes("application/xml")]
		public Reservation PostXml([FromBody] XElement res)
		{
			return _repo.AddReservation(new Reservation
			{
				Name = res.Element("Name").Value,
				StartLocation = res.Element("StartLocation").Value,
				EndLocation = res.Element("EndLocation").Value
			});
		}

		[HttpGet("ShowReservation.{format}"), FormatFilter]
		public IEnumerable<Reservation> ShowReservation() => _repo.Reservations;
	}
}
