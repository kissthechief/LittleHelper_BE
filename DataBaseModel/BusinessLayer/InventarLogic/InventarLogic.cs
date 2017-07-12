using Dal.DTOs;
using Dal.Repositories.InventarRepository;
using System;

namespace BusinessLayer.InventarLogic
{
    /// <summary>
    /// Class that implements the logic off all inventar actions
    /// </summary>
    public class InventarLogic : IInventarLogic
    {
        private readonly IInventarRepository _inventarRepository;
        public InventarLogic(IInventarRepository inventarRepository)
        {
            _inventarRepository = inventarRepository;
        }

        public InventarDto GetUsersInventar(int id)
        {
            return _inventarRepository.GetUsersInventar(id);
        }
    }
}
