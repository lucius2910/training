using Services.Entires;

namespace Services.Interfaces
{
    public interface ITodoServices
    {
        /// <summary>
        /// Get list todo
        /// </summary>
        /// <returns></returns>
        public List<Todo> GetList();

        /// <summary>
        /// Delete todo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<int> Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Todo> Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Add(Todo data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Update(int id, Todo data);

    }
}
