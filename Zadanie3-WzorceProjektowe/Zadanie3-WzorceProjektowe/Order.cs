namespace Zadanie3_WzorceProjektowe
{
    class Order
    {
        private readonly string _name;
        public bool IsDelivery { get; }
        public DeliveryAddress? DeliveryAddress { get; }
        public OrderStatus Status { get; set; }

        public Order(string name, DeliveryAddress? deliveryAddress = null)
        {
            _name = name;
            Status = OrderStatus.New;

            if (deliveryAddress != null)
            {
                IsDelivery = true;
                DeliveryAddress = deliveryAddress;
            }
        }

        public override string ToString()
        {
            return "Order " + _name;
        }
    }
}
