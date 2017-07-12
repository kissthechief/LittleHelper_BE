using Dal.DTOs;

namespace BusinessLayer.FoodLogic
{
    public interface IFoodLogic
    {
        InventarDto GetInventar(int userId);
    }
}