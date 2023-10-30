using Services.Entires;

namespace Services.Interfaces
{
    public interface IGiaovienServices
    {
        /// <summary>
        /// Get list todo
        /// </summary>
        /// <returns></returns>
        public List<Giaovien> GetList();

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
        public Task<Giaovien> Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Add(Giaovien data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Update(int id, Giaovien data);

    }
}
