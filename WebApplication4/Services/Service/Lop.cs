using Microsoft.EntityFrameworkCore;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;

namespace Services.Service
{
    public class LopServices : ILopServices
    {
        private MyContextContext _db;

        public LopServices(MyContextContext db)
        {
            _db = db;
        }

        public List<Lop> GetList()
        {
            var lopss = _db.lops.ToList();

            return lopss;
        }

        public async Task<int> Delete(int id)
        {
            var lopss = _db.lops.ToList();

            var lopDel = await _db.lops.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.lops.Remove(lopDel);
            return await _db.SaveChangesAsync();
        }

        public async Task<Lop> Find(int id)
        {
            return await _db.lops.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Add(Lop data)
        {
            _db.lops.Add(data);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Update(int id, Lop data)
        {
            // check todo exist
            var lop = await this.Find(id);
            if (lop == null) return 0;

            lop.MaLop = data.MaLop;
            lop.Ten = data.Ten;
          



            // Update
            _db.lops.Update(data);
            return await _db.SaveChangesAsync();
        }
    }
}
