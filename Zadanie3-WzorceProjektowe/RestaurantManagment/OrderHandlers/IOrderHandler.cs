using RestaurantManagment.Orders;

namespace RestaurantManagment.OrderHandlers
{
    public interface IOrderHandler
    {
        IOrderHandler? SetNext(IOrderHandler? order);
        Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant);
    }
}
