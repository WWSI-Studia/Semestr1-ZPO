using RestaurantManagment.Orders;

namespace RestaurantManagment.Staff
{
    class Cook(string name) : Employee(name)
    {
        public override async Task<IOrder> ProcessOrderAsync(IOrder order)
        {
            Console.WriteLine($"Cook {_name} is preparing a meal: " + order.ToString());

            await Task.Delay(5000);

            Console.WriteLine($"Cook {_name} is available again, after preparing: " + order.ToString());

            return order;
        }
    }
}
