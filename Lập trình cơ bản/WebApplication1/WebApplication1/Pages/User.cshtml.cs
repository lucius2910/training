using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Pages
{
    public class UserModel : PageModel
    {
        private readonly ILogger<UserModel> _logger;
        private MyContextContext _db;

        public List<User> datas { get; set; }

        public UserModel(ILogger<UserModel> logger, MyContextContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            this.datas = _db.users.ToList();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var userDel = await _db.users.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.users.Remove(userDel);
            await _db.SaveChangesAsync();

            return RedirectToPage("./User");
        }
    }
}