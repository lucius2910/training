using Services.Entities;

namespace Services.Interfaces
{
    public interface IHocsinhServices
    {
        /// <summary>
        /// Get list todo
        /// </summary>
        /// <returns></returns>
        public List<Hocsinh> GetList();

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
        public Task<Hocsinh> Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Add(Hocsinh data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Update(int id, Hocsinh data);

    }
}
