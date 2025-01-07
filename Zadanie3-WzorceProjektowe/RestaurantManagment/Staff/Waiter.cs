using RestaurantManagment.Orders;

namespace RestaurantManagment.Staff
{
    public class Waiter(string name) : Employee(name)
    {
        public override async Task<IOrder> ProcessOrderAsync(IOrder order)
        {
            // W zależności czy obsługuje nowe zamówienie, czy przygotowane przez kucharza.
            if (order.Status == OrderStatus.New)
            {
                Console.WriteLine($"Waiter {_name} passes order to the kitchen: " + order.Name);

                await Task.Delay(1000);

                Console.WriteLine($"Waiter {_name} is available again, after managing order: " + order.Name);
            }
            else
            {
                Console.WriteLine($"Waiter {_name} prepares ready order: " + order.Name);

                await Task.Delay(2000);

                Console.WriteLine($"Waiter {_name} is available again, after managing order: " + order.Name);
            }

            return order;
        }

        public override string ToString()
        {
            return $"Waiter {_name}";
        }
    }
}