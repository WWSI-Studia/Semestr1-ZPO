namespace Zadanie3_WzorceProjektowe
{
    class Order
    {
        public bool IsDelivery { get; }
        public DeliveryAddress? DeliveryAddress { get; }
        public OrderStatus Status { get; set; }

        public Order(DeliveryAddress? deliveryAddress = null)
        {
            Status = OrderStatus.New;

            if (deliveryAddress != null)
            {
                IsDelivery = true;
                DeliveryAddress = deliveryAddress;
            }
        }
    }
}
