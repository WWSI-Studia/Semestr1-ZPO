using Zadanie3_WzorceProjektowe.Orders;
using Zadanie3_WzorceProjektowe.Staff;

namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    class InKitchenOrderHandler : OrderHandler
    {
        public override async Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant)
        {
            if (order.GetOrderStatus() == OrderStatus.In_Kitchen)
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
                }
            }

            // Zawsze przesyłamy zamówienie dalej do kolejnego handlera
            return await base.HandleAsync(order, restaurant);
        }
    }
}
