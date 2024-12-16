using Zadanie3_WzorceProjektowe.Staff;

namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    class NewOrderHandler : OrderHandler
    {
        public override async Task<Order?> HandleAsync(Order order, Restaurant restaurant)
        {
            if (order.Status == OrderStatus.New)
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
                    order.Status = OrderStatus.In_Kitchen;

                    waiter.MarkAsNotBusy();
                }
            }

            // Zawsze przesyłamy zamówienie dalej do kolejnego handlera
            return await base.HandleAsync(order, restaurant);
        }
    }
}