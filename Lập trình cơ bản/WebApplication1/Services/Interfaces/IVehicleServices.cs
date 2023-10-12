using Services.Entires;
using Services.Entities;

namespace Services.Interfaces
{
    public interface IVehicleServices
    {
        /// <summary>
        /// Get list Vehicle
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetList();

        /// <summary>
        /// Delete Vehicle by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<int> Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Vehicle> Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Add(Vehicle data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> Update(Vehicle data);
    }
}
