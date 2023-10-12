using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;
using Services.Services;

namespace WebApplication1.Pages
{
    public class VehicleModel : PageModel
        {
        private readonly ILogger<VehicleModel> _logger;
        public List<Vehicle> datas { get; set; }
        private IVehicleServices _vehicleService { get; set; }


        public VehicleModel(ILogger<VehicleModel> logger, IVehicleServices vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        public void OnGet()
        {
            this.datas = _vehicleService.GetList();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _vehicleService.Delete(id);
            return RedirectToPage("./Vehicle");
        }
    }
}