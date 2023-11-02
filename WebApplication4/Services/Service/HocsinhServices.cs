using Microsoft.EntityFrameworkCore;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;

namespace Services.Service
{
    public class HocsinhServices : IHocsinhServices
    {
        private MyContextContext _db;

        public HocsinhServices(MyContextContext db)
        {
            _db = db;
        }

        public List<Hocsinh> GetList()
        {
            var hocsinhss = _db.hocsinhs.Include(x => x.Lop).ToList();

            return hocsinhss;
        }

        public async Task<int> Delete(int id)
        {
            var hocsinhss = _db.hocsinhs.ToList();

            var hocsinhDel = await _db.hocsinhs.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.hocsinhs.Remove(hocsinhDel);
            return await _db.SaveChangesAsync();
        }

        public async Task<Hocsinh> Find(int id)
        {
            return await _db.hocsinhs.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Add(Hocsinh data)
        {
            _db.hocsinhs.Add(data);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Hocsinh data)
        {
            // check todo exist
            var hocsinh = await this.Find(id);
            if (hocsinh == null) return 0;

            hocsinh.Ma = data.Ma;
            hocsinh.Ten = data.Ten;
            hocsinh.LopId = data.LopId;
            hocsinh.NgaySinh = data.NgaySinh;



            // Update
            _db.hocsinhs.Update(data);
            return await _db.SaveChangesAsync();
        }
    }
}
