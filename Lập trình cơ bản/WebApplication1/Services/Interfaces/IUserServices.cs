using Services.Entities;

namespace Services.Interfaces
{
	public interface IUserServices
	{
		/// <summary>
		/// Get list user
		/// </summary>
		/// <returns></returns>
		public List<User> GetList();

		/// <summary>
		/// Delete user by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<int> Delete(int id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<User> Find(int id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Task<int> Add(User data);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Task<int> Update(User data);
	}
}

