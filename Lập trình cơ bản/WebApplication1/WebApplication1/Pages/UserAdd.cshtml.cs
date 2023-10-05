using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Entities;
using WebApplication1.Migrations;

namespace WebApplication1.Pages
{
    public class UserAddModel : PageModel
    {
		
		private readonly ILogger<UserModel> _logger;
		private MyContextContext _db;

		[BindProperty]
		public User UserData { get; set; }

		public UserAddModel(ILogger<UserModel> logger, MyContextContext db) {
			_db = db;
			_logger = logger;
		}
        public void OnGet(int? id)
        {
			if (id.HasValue) // Nếu id  có giá trị thì mới lấy dữ liệu từ trong Db
			{
				UserData = _db.users.Find(id);
            }
			// Nếu ID không có giá trị, không làm gì
        }

        public async Task<IActionResult> OnPostAsync() {
			// validate dữ liệu
			if (!ModelState.IsValid)
			{
				return Page();
			}

			// Kiểm tra user xem có id hay không 
			if(UserData.Id != 0)
			{
                _db.users.Update(UserData);// User có id là case update

            }
			else
			{
                _db.users.Add(UserData); // User không có id là case thêm mới
            }

			// Lưu dữ liệu vào database
			await _db.SaveChangesAsync();

			// Quay lại trang danh sách & hiển thị lại danh sách user
			return RedirectToPage("./User");
		}
	}
}
