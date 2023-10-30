using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;

namespace WebApplication4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Giaovien> datas { get; set; }

        private IGiaovienServices _giaovienService { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IGiaovienServices giaovienService)
        {
            _logger = logger;
            _giaovienService = giaovienService;

        }

        public void OnGet()
        {
            this.datas = _giaovienService.GetList();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _giaovienService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}