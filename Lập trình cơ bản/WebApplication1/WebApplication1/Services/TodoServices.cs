using Microsoft.EntityFrameworkCore;
using WebApplication1.Entires;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class TodoServices : ITodoServices
    {
        private MyContextContext _db;

        public TodoServices(MyContextContext db)
        {
            _db = db;
        }

        public List<Todo> GetList()
        {
            var todos = _db.totos.ToList();

            return todos;
        }

        public async Task<int> Delete(int id)
        {
            var todos = _db.totos.ToList();

            var todoDel = await _db.totos.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.totos.Remove(todoDel);
            return await _db.SaveChangesAsync();
        }

        public async Task<Todo> Find(int id)
        {
            return await _db.totos.Where( x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Add(Todo data)
        {
            _db.totos.Add(data);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Update(Todo data)
        {
            _db.totos.Update(data);
            return await _db.SaveChangesAsync();
        }
    }
}
