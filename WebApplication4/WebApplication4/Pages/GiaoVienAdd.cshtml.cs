using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;
using Services.Migrations;
using Services.Services;

namespace WebApplication4.Pages
{
    public class GiaoVienAddModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private IGiaovienServices _giaovienService;


        [BindProperty]
        public Giaovien GiaoVienData { get; set; }

        public GiaoVienAddModel(ILogger<IndexModel> logger, IGiaovienServices giaovienService)
        {
            _giaovienService = giaovienService;
            _logger = logger;
        }
        public async Task OnGet(int? id)
        {
            if (id.HasValue) // Nếu id  có giá trị thì mới lấy dữ liệu từ trong Db
                GiaoVienData = await _giaovienService.Find(id.HasValue ? id.Value : 0);


            // Nếu ID không có giá trị, không làm gì
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // validate dữ liệu
            if (!ModelState.IsValid)
                return Page();

            // Kiểm tra user xem có id hay không 
            if (GiaoVienData.Id != 0) ;
            //await _giaovienService.Update(GiaoVienData);// User có id là case update
            else
                await _giaovienService.Add(GiaoVienData); // User không có id là case thêm mới

            // Quay lại trang danh sách & hiển thị lại danh sách user
            return RedirectToPage("./Giaovien");
        }
    }
}
