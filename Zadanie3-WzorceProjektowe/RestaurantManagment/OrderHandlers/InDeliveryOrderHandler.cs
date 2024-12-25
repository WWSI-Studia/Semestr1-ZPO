using RestaurantManagment.Orders;
using RestaurantManagment.Staff;

namespace RestaurantManagment.OrderHandlers
{
    class InDeliveryOrderHandler : OrderHandler
    {
        public override async Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant)
        {
            if (order.GetOrderStatus() == OrderStatus.In_Delivery && order.IsDelivery)
            {
                Deliveryman? deliveryman;
                // Zapewniamy, ¿eby pracownik zosta³ zaznaczony jako zajêty i zosta³ przypisany tylko do 1 zadania.
                lock (_lock)
                {
                    deliveryman = restaurant.GetAvailableDeliveryman();
                    deliveryman?.MarkAsBusy();
                }

                if (deliveryman != null)
                {
                    order = await deliveryman.ProcessOrderAsync(order);
                    order.SetOrderStatus(OrderStatus.Completed);

                    deliveryman.MarkAsNotBusy();
                }
            }
            else if (order.GetOrderStatus() == OrderStatus.In_Delivery)
            {
                order.SetOrderStatus(OrderStatus.Completed);
            }

            // Zawsze przesy³amy zamówienie dalej do kolejnego handlera
            return await base.HandleAsync(order, restaurant);
        }
    }
}
