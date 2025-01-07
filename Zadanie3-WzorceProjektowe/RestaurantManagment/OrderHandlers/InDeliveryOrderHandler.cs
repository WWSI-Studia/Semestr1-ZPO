using RestaurantManagment.Orders;
using RestaurantManagment.Staff;

namespace RestaurantManagment.OrderHandlers
{
    public class InDeliveryOrderHandler : OrderHandler
    {
        public override async Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant)
        {
            if (order.Status == OrderStatus.In_Delivery && order.IsDelivery)
            {
                Deliveryman? deliveryman;
                // Zapewniamy, �eby pracownik zosta� zaznaczony jako zaj�ty i zosta� przypisany tylko do 1 zadania.
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
            else if (order.Status == OrderStatus.In_Delivery)
            {
                order.SetOrderStatus(OrderStatus.Completed);
            }

            // Zawsze przesy�amy zam�wienie dalej do kolejnego handlera
            return await base.HandleAsync(order, restaurant);
        }
    }
}
