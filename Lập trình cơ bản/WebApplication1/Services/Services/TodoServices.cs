using Microsoft.EntityFrameworkCore;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;

namespace Services.Services
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

        public async Task<int> Update(int id, Todo data)
        {
			// check todo exist
			var todo = await this.Find(id);
			if (todo == null) return 0;

			todo.Title = data.Title;
			todo.Content = data.Content;
			todo.StartDate = data.StartDate;
			todo.EndDate = data.EndDate;
			todo.Status = data.Status;


			// Update
			_db.totos.Update(data);
			return await _db.SaveChangesAsync();
		}
    }
}
