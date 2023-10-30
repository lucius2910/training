using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Entities;
using Services.Interfaces;

namespace WebApplication4.Pages
{
	public class HocSinhModel : PageModel
    {
        private readonly ILogger<HocSinhModel> _logger;
        public List<Hocsinh> datas { get; set; }
        private IHocsinhServices _hocsinhService { get; set; }

        public HocSinhModel(ILogger<HocSinhModel> logger, IHocsinhServices hocsinhService)
        {
            _logger = logger;
            _hocsinhService = hocsinhService;

        }

        public void OnGet()
        {
            this.datas = _hocsinhService.GetList();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _hocsinhService.Delete(id);
            return RedirectToPage("./hocsinh");
        }
    }
}
