namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    interface IOrderHandler
    {
        IOrderHandler? SetNext(IOrderHandler? order);
        Task<Order?> HandleAsync(Order order, Restaurant restaurant);
    }
}
