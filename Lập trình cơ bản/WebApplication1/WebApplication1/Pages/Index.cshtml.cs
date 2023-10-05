using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Entires;
using WebApplication1.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private MyContextContext _db;
        public List<Todo> datas { get; set; }

        public IndexModel(ILogger<IndexModel> logger, MyContextContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            this.datas = _db.totos.ToList();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var todoDel = await _db.totos.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.totos.Remove(todoDel);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Todo");
        }
    }
}