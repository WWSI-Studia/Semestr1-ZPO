using Zadanie3_WzorceProjektowe.Staff;

namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    class InKitchenOrderHandler : OrderHandler
    {
        public override Order? Handle(Order order, Restaurant restaurant)
        {
            if (order.Status == OrderStatus.In_Kitchen)
            {
                Cook? cook = restaurant.GetAvailableCook();
                if (cook != null)
                {
                    order = cook.ProcessOrder(order);
                    order.Status = OrderStatus.Prepared;
                }
            }

            // Zawsze przesyłamy zamówienie dalej do kolejnego handlera
            return base.Handle(order, restaurant);
        }
    }
}
