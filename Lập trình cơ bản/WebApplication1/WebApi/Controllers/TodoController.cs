using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Services.Entires;
using Services.Interfaces;
using Services.Request;
using Services.Response;

namespace WebApi.Controllers
{
	[Route("api/todo")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private ITodoServices _todoService { get; set; }
		private IMapper _mapper { get; set; }

		public TodoController(ITodoServices todoService, IMapper mapper)
        {
			_todoService = todoService;
            _mapper = mapper;
		}

		
		[HttpGet]
		[Route("")]
		public IActionResult Get() {
			var todos = _todoService.GetList();

            var itemResponse = _mapper.Map<List<TodoResponse>>(todos);

            if (itemResponse.Count > 0)
				return Ok(itemResponse);
			else
				return BadRequest(itemResponse);
		}

		[HttpPost]
		[Route("add-new")]
		public async Task<IActionResult> AddNew([FromBody] TodoRequest item)
		{
            var validator = new TodoRequestValidator();

            // Execute the validator.
            ValidationResult results = validator.Validate(item);

            // Inspect any validation failures.
            bool success = results.IsValid;
            List<ValidationFailure> failures = results.Errors;
			if(failures.Count > 0)
                return BadRequest(failures);

            //  Convert TodoRequest => Todo
            var itemDB = _mapper.Map<Todo>(item);

            var rowFetched = await _todoService.Add(itemDB);
			if (rowFetched > 0)
				return Ok(new { message = "add success" });
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


