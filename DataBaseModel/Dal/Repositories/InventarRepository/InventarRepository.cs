using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.DTOs;
using Dal.Context;

namespace Dal.Repositories.InventarRepository
{
    public class InventarRepository : IInventarRepository
    {
        private readonly ILittleHelperContext _context;

        public InventarRepository(ILittleHelperContext context)
        {
            _context = context;
        }
        public InventarDto GetUsersInventar(int id)
        {
            var inventarItems = _context.InventarView.Where(inv => inv.User_Id == id).ToList();
            var inventar = new InventarDto();
            inventar.InventarName = inventarItems.First().InventarGuid;
            inventarItems.ForEach(x => {
                inventar.Foods.Add(new FoodDto()
                {
                    FoodSort = x.FoodSort,
                    Messurement = x.Messurement,
                    Name = x.FoodName
                });
            });

            return inventar;
        }
    }
}
