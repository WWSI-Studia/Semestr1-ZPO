using Zadanie3_WzorceProjektowe.Staff;

namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    class PreparedOrderHandler : OrderHandler
    {
        public override Order? Handle(Order order, Restaurant restaurant)
        {
            if (order.Status == OrderStatus.Prepared && !order.IsDelivery)
            {
                Waiter? waiter = restaurant.GetAvailableWaiter();
                if (waiter != null)
                {
                    Order processedOrder = waiter.ProcessOrder(order);

                    order.Status = OrderStatus.Completed;
                    //restaurant.AddOrder(processedOrder);
                }
            }
            else if (order.Status == OrderStatus.Prepared)
            {
                order.Status = OrderStatus.In_Delivery;
            }

            // Zawsze przesyłamy zamówienie dalej do kolejnego handlera
            return base.Handle(order, restaurant);
        }
    }
}
