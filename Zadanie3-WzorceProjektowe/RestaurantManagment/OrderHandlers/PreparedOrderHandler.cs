using RestaurantManagment.Orders;
using RestaurantManagment.Staff;

namespace RestaurantManagment.OrderHandlers
{
    class PreparedOrderHandler : OrderHandler
    {
        public override async Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant)
        {
            if (order.Status == OrderStatus.Prepared)
            {
                Waiter? waiter;
                // Zapewniamy, żeby pracownik został zaznaczony jako zajęty i został przypisany tylko do 1 zadania.
                lock (_lock)
                {
                    waiter = restaurant.GetAvailableWaiter();
                    waiter?.MarkAsBusy();
                }

                await Task.Delay(3000);

                if (waiter != null)
                {
                    IOrder processedOrder = await waiter.ProcessOrderAsync(order);

                    order.SetOrderStatus(OrderStatus.In_Delivery);

                    waiter.MarkAsNotBusy();
                }
            }

            // Zawsze przesyłamy zamówienie dalej do kolejnego handlera
            return await base.HandleAsync(order, restaurant);
        }
    }
}
