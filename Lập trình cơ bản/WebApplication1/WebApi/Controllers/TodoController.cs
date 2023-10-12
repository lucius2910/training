using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Entires;
using Services.Interfaces;

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

		[Route("/")]
		[HttpGet]
		public IActionResult Get() {
			var todos = _todoService.GetList();
			if(todos.Count > 0)
				return Ok(todos);
			else
				return BadRequest(todos);
		}

		[Route("/add-new")]
		[HttpPut]
		public async Task<IActionResult> AddNew([FromBody] Todo item)
		{
			var rowFetched = await _todoService.Add(item);
			if (rowFetched > 0)
				return Ok(new {message = "add success"});
			else
				return BadRequest(new { message = "add fail" });
		}


		[Route("/delete/{id}")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var rowFetched = await _todoService.Delete(id);
			if (rowFetched > 0)
				return Ok(new { message = "delete success" });
			else
				return BadRequest(new { message = "delete fail" });
		}
	}
}
