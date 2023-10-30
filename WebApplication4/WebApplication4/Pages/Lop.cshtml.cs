using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;

namespace WebApplication4.Pages
{
    public class LopModel : PageModel
    {
        private readonly ILogger<LopModel> _logger;
        public List<Lop> datas { get; set; }
        private ILopServices _lopService { get; set; }

        public LopModel(ILogger<LopModel> logger, ILopServices lopService)
        {
            _logger = logger;
            _lopService = lopService;

        }

        public void OnGet()
        {
            this.datas = _lopService.GetList();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _lopService.Delete(id);
            return RedirectToPage("./lop");
        }
    }
}
