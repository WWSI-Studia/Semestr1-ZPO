using RestaurantManagment.Orders;

namespace RestaurantManagment.Staff
{
    public class Deliveryman(string name) : Employee(name)
    {
        public override async Task<IOrder> ProcessOrderAsync(IOrder order)
        {
            Console.WriteLine($"Deliveryman {_name} delivers order to customer: " + order.Name);

            await Task.Delay(3000);

            Console.WriteLine($"Deliveryman {_name} is available again, after delivering order: " + order.Name);

            return order;
        }

        public override string ToString()
        {
            return $"Deliveryman {_name}";
        }
    }
}
