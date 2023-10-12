using Microsoft.EntityFrameworkCore;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;


namespace Services.Services
{
    public class VehicleServices : IVehicleServices
    {
        private MyContextContext _db;

        public VehicleServices(MyContextContext db)
        {
            _db = db;
        }

        public List<Vehicle> GetList()
        {
            var vehicless = _db.vehicles.ToList();

            return vehicless;
        }

        public async Task<int> Delete(int id)
        {
            var vehicless = _db.vehicles.ToList();

            var vehicleDel = await _db.vehicles.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.vehicles.Remove(vehicleDel);
            return await _db.SaveChangesAsync();
        }

        public async Task<Vehicle> Find(int id)
        {
            return await _db.vehicles.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Add(Vehicle data)
        {
            _db.vehicles.Add(data);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Update(Vehicle data)
        {
            _db.vehicles.Update(data);
            return await _db.SaveChangesAsync();
        }
    }
}