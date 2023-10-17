using Microsoft.AspNetCore.Mvc;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;

namespace WebApi.Controllers
{
	[Route("api/users/")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private IUserServices _userService { get; set; }

		public UserController(IUserServices userService)
		{
			_userService = userService;
		}

		[Route("")]
		[HttpGet]
		public IActionResult Get()
		{
			var users = _userService.GetList();
			if (users.Count > 0)
				return Ok(users);
			else
				return BadRequest(users);
		}

		[Route("add-new")]
		[HttpPost]
		public async Task<IActionResult> AddNew([FromBody] User item)
		{
			var rowFetched = await _userService.Add(item);
			if (rowFetched > 0)
				return Ok(new { message = "add success" });
			else
				return BadRequest(new { message = "add fail" });
		}


		[Route("delete/{id}")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var rowFetched = await _userService.Delete(id);
			if (rowFetched > 0)
				return Ok(new { message = "delete success" });
			else
				return BadRequest(new { message = "delete fail" });

		}

		[Route("update/{id}")]
		[HttpPut]

		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] User item)
		{
			//  Update
			var rowFetched = await _userService.Update(id, item);
			if (rowFetched > 0)
				return Ok(new { message = "Update success" });
			else
				return BadRequest(new { message = "Update fail" });
		}

	}
}