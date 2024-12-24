using RestaurantManagment.Orders;

namespace RestaurantManagment.OrderHandlers
{
    interface IOrderHandler
    {
        IOrderHandler? SetNext(IOrderHandler? order);
        Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant);
    }
}
