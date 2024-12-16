namespace Zadanie3_WzorceProjektowe.Staff
{
    class Waiter(string name) : Employee(name)
    {
        public override async Task<Order> ProcessOrderAsync(Order order)
        {
            // TODO w zależności czy przyjmuje czy zanosi
            Console.WriteLine($"Waiter {_name} passes order to the kitchen: " + order.ToString());

            await Task.Delay(3000);

            Console.WriteLine($"Waiter {_name} is available again, after managing: " + order.ToString());

            return order;
        }
    }
}