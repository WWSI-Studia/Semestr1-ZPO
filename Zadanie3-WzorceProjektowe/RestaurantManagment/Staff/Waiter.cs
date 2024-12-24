using RestaurantManagment.Orders;

namespace RestaurantManagment.Staff
{
    class Waiter(string name) : Employee(name)
    {
        public override async Task<IOrder> ProcessOrderAsync(IOrder order)
        {
            // TODO w zależności czy przyjmuje czy zanosi
            Console.WriteLine($"Waiter {_name} passes order to the kitchen: " + order.Name);

            await Task.Delay(3000);

            Console.WriteLine($"Waiter {_name} is available again, after managing: " + order.Name);

            return order;
        }

        public override string ToString()
        {
            return $"Waiter {_name}";
        }
    }
}