using Dal.DTOs;

namespace BusinessLayer.InventarLogic
{
    public interface IInventarLogic
    {
        /// <summary>
        /// Call this method to get the inventar of a user to collect the food 
        /// </summary>
        /// <param name="id">The users id</param>
        /// <returns>Returns a list of all food a user has</returns>
        InventarDto GetUsersInventar(int id);
    }
}
