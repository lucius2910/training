using Services.Entires;

namespace Services.Interfaces
{
    public interface ILopServices
    {
        /// <summary>
        /// Get list todo
        /// </summary>
        /// <returns></returns>
        public List<Lop> GetList();

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
        public Task<Lop> Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Add(Lop data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Update(int id, Lop data);

    }
}
