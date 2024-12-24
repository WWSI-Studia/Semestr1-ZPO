using RestaurantManagment.Orders;

namespace RestaurantManagment.Staff
{
    interface IEmployee
    {
        public Task<IOrder> ProcessOrderAsync(IOrder order);
    }
}
