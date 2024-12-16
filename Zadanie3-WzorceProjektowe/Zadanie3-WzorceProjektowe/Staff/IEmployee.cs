namespace Zadanie3_WzorceProjektowe.Staff
{
    interface IEmployee
    {
        public Task<Order> ProcessOrderAsync(Order order);
    }
}
