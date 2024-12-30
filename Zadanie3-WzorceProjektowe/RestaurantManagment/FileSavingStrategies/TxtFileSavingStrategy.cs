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
                if (order.IsDelivery && order.DeliveryAddress != null)
                {
                    writer.WriteLine($"Order Name: {order.Name}, TotalCost: {order.GetTotalCost()}, Delivery Address: {order.DeliveryAddress.City}, {order.DeliveryAddress.ZipCode}, {order.DeliveryAddress.Street} {order.DeliveryAddress.FlatNumber ?? ""}");
                }
                else
                {
                    writer.WriteLine($"Order Name: {order.Name}, TotalCost: {order.GetTotalCost()}");
                }
            }
        }
    }
}
