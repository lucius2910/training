using Microsoft.EntityFrameworkCore;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;

namespace Services.Service
{
    public class GiaovienServices : IGiaovienServices
    {
        private MyContextContext _db;

        public GiaovienServices(MyContextContext db)
        {
            _db = db;
        }

        public List<Giaovien> GetList()
        {
            var giaovienss = _db.giaoviens.ToList();

            return giaovienss;
        }

        public async Task<int> Delete(int id)
        {
            var giaovienss = _db.giaoviens.ToList();

            var giaovienDel = await _db.giaoviens.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.giaoviens.Remove(giaovienDel);
            return await _db.SaveChangesAsync();
        }

        public async Task<Giaovien> Find(int id)
        {
            return await _db.giaoviens.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Add(Giaovien data)
        {
            _db.giaoviens.Add(data);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Giaovien data)
        {
            // check todo exist
            var giaovien = await this.Find(id);
            if (giaovien == null) return 0;

            giaovien.Id = data.Id;
            giaovien.Ma = data.Ma;
            giaovien.Ten = data.Ten;
            giaovien.LopId = data.LopId;
            


            // Update
            _db.giaoviens.Update(data);
            return await _db.SaveChangesAsync();
        }
    }
}
