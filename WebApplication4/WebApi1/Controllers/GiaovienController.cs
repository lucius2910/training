using Microsoft.AspNetCore.Mvc;
using Services.Entires;
using Services.Interfaces;


namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/giaovien")]
    public class GiaovienController : ControllerBase
    {
        private IGiaovienServices _giaovienService { get; set; }

        public GiaovienController(IGiaovienServices giaovienService)
        {
            _giaovienService = giaovienService;

        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var giaovienss = _giaovienService.GetList();

            if (giaovienss.Count > 0)
                return Ok(giaovienss);
            else
                return BadRequest(giaovienss);
        }

        [HttpPost]
        [Route("add-new")]
        public async Task<IActionResult> AddNew([FromBody] Giaovien item)
        {


            var rowFetched = await _giaovienService.Add(item);
            if (rowFetched > 0)
                return Ok(new { message = "add success" });
            else
                return BadRequest(new { message = "add fail" });
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var rowFetched = await _giaovienService.Delete(id);
            if (rowFetched > 0)
                return Ok(new { message = "delete success" });
            else
                return BadRequest(new { message = "delete fail" });
        }

        [Route("update/{id}")]
        [HttpPut]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Giaovien item)
        {
            //  Update
            var rowFetched = await _giaovienService.Update(id, item);
            if (rowFetched > 0)
                return Ok(new { message = "Update success" });
            else
                return BadRequest(new { message = "Update fail" });
        }

    }
}