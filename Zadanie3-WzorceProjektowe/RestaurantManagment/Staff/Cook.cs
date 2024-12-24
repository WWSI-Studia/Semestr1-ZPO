using RestaurantManagment.Orders;

namespace RestaurantManagment.Staff
{
    class Cook(string name) : Employee(name)
    {
        public override async Task<IOrder> ProcessOrderAsync(IOrder order)
        {
            Console.WriteLine($"Cook {_name} is preparing a meal: " + order.Name);

            await Task.Delay(5000);

            Console.WriteLine($"Cook {_name} is available again, after preparing: " + order.Name);

            return order;
        }

        public override string ToString()
        {
            return $"Cook {_name}";
        }
    }
}
