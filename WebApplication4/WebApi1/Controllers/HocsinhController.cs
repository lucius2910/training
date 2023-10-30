using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Interfaces;


namespace WebApi1.Controllers
{
    [Route("api/hocsinh/")]
    [ApiController]
    public class HocsinhController : ControllerBase
    {
        private IHocsinhServices _hocsinhService { get; set; }

        public HocsinhController(IHocsinhServices hocsinhService)
        {
            _hocsinhService = hocsinhService;

        }


        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var hocsinhss = _hocsinhService.GetList();

            if (hocsinhss.Count > 0)
                return Ok(hocsinhss);
            else
                return BadRequest(hocsinhss);
        }

        [HttpPost]
        [Route("add-new")]
        public async Task<IActionResult> AddNew([FromBody] Hocsinh item)
        {


            var rowFetched = await _hocsinhService.Add(item);
            if (rowFetched > 0)
                return Ok(new { message = "add success" });
            else
                return BadRequest(new { message = "add fail" });
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var rowFetched = await _hocsinhService.Delete(id);
            if (rowFetched > 0)
                return Ok(new { message = "delete success" });
            else
                return BadRequest(new { message = "delete fail" });
        }

        [Route("update/{id}")]
        [HttpPut]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Hocsinh item)
        {
            //  Update
            var rowFetched = await _hocsinhService.Update(id, item);
            if (rowFetched > 0)
                return Ok(new { message = "Update success" });
            else
                return BadRequest(new { message = "Update fail" });
        }

    }
}