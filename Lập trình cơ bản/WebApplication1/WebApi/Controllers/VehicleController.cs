
using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Interfaces;

namespace WebApi.Controllers
{
	[Route("api/vehicle/")]
	[ApiController]
	public class VehicleController : ControllerBase
	{
		private IVehicleServices _vehicleService { get; set; }

		public VehicleController(IVehicleServices vehicleService)
		{
			_vehicleService = vehicleService;
		}

		[Route("")]
		[HttpGet]
		public IActionResult Get()
		{
			var vehicles = _vehicleService.GetList();
			if (vehicles.Count > 0)
				return Ok(vehicles);
			else
				return BadRequest(vehicles);
		}

		[Route("add-new")]
		[HttpPut]
		public async Task<IActionResult> AddNew([FromBody] Vehicle item)
		{
			var rowFetched = await _vehicleService.Add(item);
			if (rowFetched > 0)
				return Ok(new { message = "add success" });
			else
				return BadRequest(new { message = "add fail" });
		}


		[Route("delete/{id}")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var rowFetched = await _vehicleService.Delete(id);
			if (rowFetched > 0)
				return Ok(new { message = "delete success" });
			else
				return BadRequest(new { message = "delete fail" });
		}
	}
}
