using Microsoft.EntityFrameworkCore;
using Services.Entires;
using Services.Entities;
using Services.Interfaces;


namespace Services.Services
{	
	public class UserServices : IUserServices
	{
		private MyContextContext _db;

		public UserServices(MyContextContext db)
		{
			_db = db;
		}

		public List<User> GetList()
		{
			var user = _db.users.ToList();

			return user;
		}

		public async Task<int> Delete(int id)
		{
			var users = _db.users.ToList();

			var userDel = await _db.users.Where(x => x.Id == id).FirstOrDefaultAsync();
			_db.users.Remove(userDel);
			return await _db.SaveChangesAsync();
		}

		public async Task<User> Find(int id)
		{
			return await _db.users.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<int> Add(User data)
		{
			_db.users.Add(data);
			return await _db.SaveChangesAsync();
		}

		public async Task<int> Update(int id, User data)
		{
			// check userr exist
			var user = await this.Find(id);
			if (user == null) return 0;

			user.Name = data.Name;
			user.Birthday = data.Birthday;

			// Update
			_db.users.Update(data);
			return await _db.SaveChangesAsync();
		}
	}
}