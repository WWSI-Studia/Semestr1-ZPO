using Zadanie3_WzorceProjektowe.Orders;

namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    interface IOrderHandler
    {
        IOrderHandler? SetNext(IOrderHandler? order);
        Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant);
    }
}
