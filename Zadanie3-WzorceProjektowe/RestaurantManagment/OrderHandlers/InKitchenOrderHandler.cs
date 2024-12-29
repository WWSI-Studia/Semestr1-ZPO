using RestaurantManagment.Orders;
using RestaurantManagment.Staff;

namespace RestaurantManagment.OrderHandlers
{
    class InKitchenOrderHandler : OrderHandler
    {
        public override async Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant)
        {
            if (order.Status == OrderStatus.In_Kitchen)
            {
                Cook? cook;
                // Zapewniamy, żeby pracownik został zaznaczony jako zajęty i został przypisany tylko do 1 zadania.
                lock (_lock)
                {
                    cook = restaurant.GetAvailableCook();
                    cook?.MarkAsBusy();
                }

                if (cook != null)
                {
                    order = await cook.ProcessOrderAsync(order);
                    order.SetOrderStatus(OrderStatus.Prepared);

                    cook.MarkAsNotBusy();
                }
            }

            // Zawsze przesyłamy zamówienie dalej do kolejnego handlera
            return await base.HandleAsync(order, restaurant);
        }
    }
}
