using Dal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories.InventarRepository
{
    public interface IInventarRepository
    {
        /// <summary>
        /// Call this method to get the inventar of a user to collect the food 
        /// </summary>
        /// <param name="id">The users id</param>
        /// <returns>Returns a list of all food a user has</returns>
        InventarDto GetUsersInventar(int id);
    }
}
