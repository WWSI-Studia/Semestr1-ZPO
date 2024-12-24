using RestaurantManagment.Meals;

namespace RestaurantManagment.Orders
{
    class Order : IOrder
    {
        private readonly string _name;
        private readonly List<Meal> _meals = [];
        private double _deliveryCost;
        private OrderStatus _status;
        public bool IsDelivery { get; }
        public DeliveryAddress? DeliveryAddress { get; }

        public Order(string name, DeliveryAddress? deliveryAddress = null)
        {
            _name = name;
            _status = OrderStatus.New;

            if (deliveryAddress != null)
            {
                IsDelivery = true;
                DeliveryAddress = deliveryAddress;
                _deliveryCost = 10;
            }
        }

        public void AddMeal(Meal meal)
        {
            _meals.Add(meal);
        }

        public List<Meal> GetMeals()
        {
            return _meals;
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            _status = orderStatus;
        }

        public OrderStatus GetOrderStatus()
        {
            return _status;
        }

        public void SetDeliveryCost(double cost)
        {
            _deliveryCost = cost;
        }

        public double GetDeliveryCost()
        {
            return IsDelivery ? _deliveryCost : 0;
        }

        public double GetTotalCost()
        {
            double cost = GetDeliveryCost();

            foreach (Meal meal in _meals)
            {
                cost += meal.Price;
            }

            return cost;
        }

        public override string ToString()
        {
            return "Order " + _name;
        }
    }
}
