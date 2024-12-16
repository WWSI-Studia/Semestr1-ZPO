namespace Zadanie3_WzorceProjektowe.Staff
{
    class Cook(string name) : Employee(name)
    {
        public override async Task<Order> ProcessOrderAsync(Order order)
        {
            Console.WriteLine($"Cook {_name} is preparing a meal: " + order.ToString());

            await Task.Delay(5000);

            Console.WriteLine($"Cook {_name} is available again, after preparing: " + order.ToString());

            return order;
        }
    }
}
