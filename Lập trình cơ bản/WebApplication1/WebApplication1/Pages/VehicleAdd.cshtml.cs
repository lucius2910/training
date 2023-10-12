using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Entities;
using Services.Interfaces;

namespace WebApplication1.Pages
{
    public class VehicleAddModel : PageModel
    {

        private readonly ILogger<VehicleModel> _logger;
        private IVehicleServices _vehicleService;
        private IUserServices _userService;

        [BindProperty]
        public Vehicle VehicleData { get; set; }

		[BindProperty]
		public List<User> users { get; set; }

		public VehicleAddModel(ILogger<VehicleModel> logger, IVehicleServices vehicleService , IUserServices userService)
        {
            _vehicleService = vehicleService;
            _userService = userService;
            _logger = logger;
        }

        public async Task OnGet(int? id)
        {
            if (id.HasValue) // Nếu id  có giá trị thì mới lấy dữ liệu từ trong Db
                VehicleData = await _vehicleService.Find(id.HasValue ? id.Value : 0);

			this.users = _userService.GetList();


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
            if (VehicleData.Id != 0)
            {
                await _vehicleService.Update(VehicleData);// User có id là case update

            }
            else
            {
                await _vehicleService.Add(VehicleData); // User không có id là case thêm mới
            }



            // Quay lại trang danh sách & hiển thị lại danh sách user
            return RedirectToPage("./Vehicle");
        }
    }
}
