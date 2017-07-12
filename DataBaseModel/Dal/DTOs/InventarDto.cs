using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DTOs
{
    public class InventarDto
    {
        public InventarDto()
        {
            Foods = new List<FoodDto>();
        }
        public string InventarName { get; set; }
        public int InventarId { get; set; }
        public IList<FoodDto> Foods { get; set; }
    }
}
