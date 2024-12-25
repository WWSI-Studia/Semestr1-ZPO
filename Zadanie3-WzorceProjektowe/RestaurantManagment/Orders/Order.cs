using RestaurantManagment.Meals;
using System.Text;

namespace RestaurantManagment.Orders
{
    class Order : IOrder
    {
        private readonly List<Meal> _meals;
        private double _deliveryCost;
        private OrderStatus _status;
        public string Name { get; }
        public bool IsDelivery { get; }
        public DeliveryAddress? DeliveryAddress { get; }

        public Order(string name, List<Meal> meals, DeliveryAddress? deliveryAddress = null)
        {
            Name = name;
            _meals = meals;
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
                cost += meal.GetTotalCost();
            }

            return Math.Round(cost, 2);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new($"Order {Name} {GetTotalCost()}PLN\n");

            foreach (Meal meal in _meals)
            {
                stringBuilder.Append($" - {meal.ToString()}\n");
            }

            if (DeliveryAddress != null)
            {
                stringBuilder.Append($" - Delivery {DeliveryAddress.Price}PLN\n");
            }

            return stringBuilder.ToString();
        }
    }
}
