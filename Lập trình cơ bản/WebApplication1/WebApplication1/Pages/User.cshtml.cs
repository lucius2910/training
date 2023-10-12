using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.Entities;
using Services.Interfaces;
using Services.Services;

namespace WebApplication1.Pages
{
    public class UserModel : PageModel
    {
        private readonly ILogger<UserModel> _logger;
		private IUserServices _userService;

		public List<User> datas { get; set; }

        public UserModel(ILogger<UserModel> logger, IUserServices userServices)
        {
			_userService = userServices;
			_logger = logger;
		}

        public void OnGet()
        {
			this.datas = _userService.GetList();
		}

        public async Task<IActionResult> OnPostDelete(int id)
        {
			await _userService.Delete(id);
			return RedirectToPage("./User");
		}
    }
}