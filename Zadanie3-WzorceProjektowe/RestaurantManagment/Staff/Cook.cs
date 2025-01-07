using RestaurantManagment.Orders;

namespace RestaurantManagment.Staff
{
    public class Cook(string name) : Employee(name)
    {
        public override async Task<IOrder> ProcessOrderAsync(IOrder order)
        {
            Console.WriteLine($"Cook {_name} is preparing a meal: " + order.Name);

            await Task.Delay(3000);

            Console.WriteLine($"Cook {_name} is available again, after preparing: " + order.Name);

            return order;
        }

        public override string ToString()
        {
            return $"Cook {_name}";
        }
    }
}
