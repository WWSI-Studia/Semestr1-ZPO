using RestaurantManagment.Orders;
using RestaurantManagment.Staff;

namespace RestaurantManagment.OrderHandlers
{
    class NewOrderHandler : OrderHandler
    {
        public override async Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant)
        {
            if (order.GetOrderStatus() == OrderStatus.New)
            {
                Waiter? waiter;
                // Zapewniamy, żeby pracownik został zaznaczony jako zajęty i został przypisany tylko do 1 zadania.
                lock (_lock)
                {
                    waiter = restaurant.GetAvailableWaiter();
                    waiter?.MarkAsBusy();
                }

                if (waiter != null)
                {
                    order = await waiter.ProcessOrderAsync(order);
                    order.SetOrderStatus(OrderStatus.In_Kitchen);

                    waiter.MarkAsNotBusy();
                }
            }

            // Zawsze przesyłamy zamówienie dalej do kolejnego handlera
            return await base.HandleAsync(order, restaurant);
        }
    }
}