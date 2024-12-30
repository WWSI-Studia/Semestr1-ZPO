using RestaurantManagment.Orders;

namespace RestaurantManagment.FileSavingStrategies
{
    class CsvFileSavingStrategy : IFileSavingStrategy
    {
        public void Save(List<IOrder> orders, string path)
        {
            using var writer = new StreamWriter(path);

            writer.WriteLine("OrderID,TotalCost,City,ZipCode,Street,FlatNumber");
            foreach (var order in orders)
            {
                if (order.IsDelivery && order.DeliveryAddress != null)
                {
                    writer.WriteLine($"{order.Name},{order.GetTotalCost()},{order.DeliveryAddress.City},{order.DeliveryAddress.ZipCode},{order.DeliveryAddress.Street},{order.DeliveryAddress.FlatNumber ?? "-"}");
                }
                else
                {
                    writer.WriteLine($"{order.Name},{order.GetTotalCost()},-,-,-,-");
                }
            }
        }
    }
}
