using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Entires;
using WebApplication1.Entities;
using WebApplication1.Migrations;

namespace WebApplication1.Pages
{
    public class TodoAddModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private MyContextContext _db;

        [BindProperty]
        public Todo TodoData { get; set; }

        public TodoAddModel(ILogger<IndexModel> logger, MyContextContext db)
        {
            _db = db;
            _logger = logger;
        }
        public void OnGet(int? id)
        {
            if (id.HasValue) // Nếu id  có giá trị thì mới lấy dữ liệu từ trong Db
            {
               TodoData = _db.totos.Find(id);
            }
            // Nếu ID không có giá trị, không làm gì
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // validate dữ liệu
            if (!ModelState.IsValid)
            {
                return Page();
            }   

            // Kiểm tra user xem có id hay không 
            if (TodoData.Id != null && TodoData.Id != 0)
            {
                _db.totos.Update(TodoData);// User có id là case update

            }
            else
            {
                _db.totos.Add(TodoData); // User không có id là case thêm mới
            }

            // Lưu dữ liệu vào database
            await _db.SaveChangesAsync();

            // Quay lại trang danh sách & hiển thị lại danh sách user
            return RedirectToPage("/");
        }
    }
}