using Zadanie3_WzorceProjektowe.Staff;

namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    class NewOrderHandler : OrderHandler
    {
        public override Order? Handle(Order order, Restaurant restaurant)
        {
            if (order.Status == OrderStatus.New)
            {
                Waiter? waiter = restaurant.GetAvailableWaiter();
                if (waiter != null)
                {
                    order = waiter.ProcessOrder(order);
                    order.Status = OrderStatus.In_Kitchen;
                }
            }

            // Zawsze przesyłamy zamówienie dalej do kolejnego handlera
            return base.Handle(order, restaurant);
        }
    }
}