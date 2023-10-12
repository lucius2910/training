using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Entires;
using Services.Interfaces;

namespace WebApplication1.Pages
{
    public class TodoAddModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ITodoServices _todoService;

        [BindProperty]
        public Todo TodoData { get; set; }

        public TodoAddModel(ILogger<IndexModel> logger, ITodoServices todoService)
        {
            _todoService = todoService;
            _logger = logger;
        }
        public async Task OnGet(int? id)
        {
            if (id.HasValue) // Nếu id  có giá trị thì mới lấy dữ liệu từ trong Db
               TodoData = await _todoService.Find(id.HasValue ? id.Value : 0);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // validate dữ liệu
            if (!ModelState.IsValid)
                return Page();

            // Kiểm tra user xem có id hay không 
            if (TodoData.Id != null && TodoData.Id != 0)
               await _todoService.Update(TodoData);// User có id là case update
            else
                await _todoService.Add(TodoData); // User không có id là case thêm mới

            // Quay lại trang danh sách & hiển thị lại danh sách user
            return RedirectToPage("./Index");
        }
    }
}