using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DTOs
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Messurement { get; set; }
        public string FoodSort { get; set; }
    }
}
