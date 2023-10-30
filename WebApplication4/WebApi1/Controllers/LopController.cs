using Microsoft.AspNetCore.Mvc;
using Services.Entires;
using Services.Interfaces;


namespace WebApi1.Controllers
{
    [Route("api/lop/")]
    [ApiController]
    public class LopController : ControllerBase
    {
        private ILopServices _lopService { get; set; }

        public LopController(ILopServices lopService)
        {
            _lopService = lopService;

        }


        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var lopss = _lopService.GetList();

            if (lopss.Count > 0)
                return Ok(lopss);
            else
                return BadRequest(lopss);
        }

        [HttpPost]
        [Route("add-new")]
        public async Task<IActionResult> AddNew([FromBody] Lop item)
        {


            var rowFetched = await _lopService.Add(item);
            if (rowFetched > 0)
                return Ok(new { message = "add success" });
            else
                return BadRequest(new { message = "add fail" });
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var rowFetched = await _lopService.Delete(id);
            if (rowFetched > 0)
                return Ok(new { message = "delete success" });
            else
                return BadRequest(new { message = "delete fail" });
        }

        [Route("update/{id}")]
        [HttpPut]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Lop item)
        {
            //  Update
            var rowFetched = await _lopService.Update(id, item);
            if (rowFetched > 0)
                return Ok(new { message = "Update success" });
            else
                return BadRequest(new { message = "Update fail" });
        }

    }
}