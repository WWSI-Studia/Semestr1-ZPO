using RestaurantManagment.Orders;

namespace RestaurantManagment.FileSavingStrategies
{
    interface IFileSavingStrategy
    {
        void Save(List<IOrder> orders, string path);
    }
}
