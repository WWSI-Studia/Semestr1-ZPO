using RestaurantManagment.Orders;

namespace RestaurantManagment.FileSavingStrategies
{
    public interface IFileSavingStrategy
    {
        void Save(List<IOrder> orders, string path);
    }
}
