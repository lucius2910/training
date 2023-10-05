using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Entires;
using WebApplication1.Interfaces;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Todo> datas { get; set; }
        private ITodoServices _todoService { get; set; }
        

        public IndexModel(ILogger<IndexModel> logger, ITodoServices todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        public void OnGet()
        {
            this.datas = _todoService.GetList();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _todoService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}