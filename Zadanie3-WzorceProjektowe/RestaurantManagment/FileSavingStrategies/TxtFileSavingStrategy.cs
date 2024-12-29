using RestaurantManagment.Orders;

namespace RestaurantManagment.FileSavingStrategies
{
    class TxtFileSavingStrategy : IFileSavingStrategy
    {
        public void Save(List<IOrder> orders, string path)
        {
            using var writer = new StreamWriter(path);
            foreach (var order in orders)
            {
                writer.WriteLine($"Order Name: {order.Name}, TotalCost: {order.GetTotalCost()}");
            }
        }
    }
}
