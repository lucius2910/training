using Microsoft.AspNetCore.Mvc;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;
using Services.Services;

namespace WebApi.Controllers
{
	[Route("api/todo")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private ITodoServices _todoService { get; set; }

		public TodoController(ITodoServices todoService)
        {
			_todoService = todoService;
		}

		
		[HttpGet]
		[Route("")]
		public IActionResult Get() {
			var todos = _todoService.GetList();
			if(todos.Count > 0)
				return Ok(todos);
			else
				return BadRequest(todos);
		}

		[HttpPut]
		[Route("add-new")]
		public async Task<IActionResult> AddNew([FromBody] Todo item)
		{
			var rowFetched = await _todoService.Add(item);
			if (rowFetched > 0)
				return Ok(new {message = "add success"});
			else
				return BadRequest(new { message = "add fail" });
		}


		[HttpDelete]
		[Route("delete/{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var rowFetched = await _todoService.Delete(id);
			if (rowFetched > 0)
				return Ok(new { message = "delete success" });
			else
				return BadRequest(new { message = "delete fail" });
		}

		[Route("update/{id}")]
		[HttpPut]

		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Todo item)
		{
			//  Update
			var rowFetched = await _todoService.Update(id, item);
			if (rowFetched > 0)
				return Ok(new { message = "Update success" });
			else
				return BadRequest(new { message = "Update fail" });
		}

	}
}


