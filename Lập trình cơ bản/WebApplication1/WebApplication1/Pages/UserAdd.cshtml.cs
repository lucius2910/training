using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Entities;
using Services.Interfaces;
using Services.Migrations;
using Services.Services;

namespace WebApplication1.Pages
{
    public class UserAddModel : PageModel
    {
		
		private readonly ILogger<UserModel> _logger;
        private IUserServices _userService;


        [BindProperty]
		public User UserData { get; set; }

		public UserAddModel(ILogger<UserModel> logger, IUserServices userService) {
            _userService = userService;
            _logger = logger;
        }
        public async Task OnGet(int? id)
        {
			if (id.HasValue) // Nếu id  có giá trị thì mới lấy dữ liệu từ trong Db
                UserData = await _userService.Find(id.HasValue ? id.Value : 0);

            
            // Nếu ID không có giá trị, không làm gì
        }

        public async Task<IActionResult> OnPostAsync() {
			// validate dữ liệu
			if (!ModelState.IsValid)
				return Page();

			// Kiểm tra user xem có id hay không 
			if(UserData.Id != 0)
                await _userService.Update(UserData);// User có id là case update
            else
                await _userService.Add(UserData); // User không có id là case thêm mới

			// Quay lại trang danh sách & hiển thị lại danh sách user
			return RedirectToPage("./User");
		}
	}
}
