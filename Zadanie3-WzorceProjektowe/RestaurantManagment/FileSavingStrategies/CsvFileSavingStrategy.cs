using RestaurantManagment.Orders;

namespace RestaurantManagment.FileSavingStrategies
{
    class CsvFileSavingStrategy : IFileSavingStrategy
    {
        public void Save(List<IOrder> orders, string path)
        {
            using var writer = new StreamWriter(path);
            writer.WriteLine("OrderID,TotalCost");
            foreach (var order in orders)
            {
                writer.WriteLine($"{order.Name},{order.GetTotalCost()}");
            }
        }
    }
}
