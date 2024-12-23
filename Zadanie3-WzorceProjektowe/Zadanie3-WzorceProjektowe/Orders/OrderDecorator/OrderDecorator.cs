using Zadanie3_WzorceProjektowe.Meals;

namespace Zadanie3_WzorceProjektowe.Orders.OrderDecorator
{
    abstract class OrderDecorator(IOrder order) : IOrder
    {
        private readonly IOrder _order = order;
        public bool IsDelivery { get => _order.IsDelivery; }

        public void AddMeal(Meal meal)
        {
            _order.AddMeal(meal);
        }
        public List<Meal> GetMeals()
        {
            return _order.GetMeals();
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            _order.SetOrderStatus(orderStatus);
        }

        public OrderStatus GetOrderStatus()
        {
            return _order.GetOrderStatus();
        }

        public virtual void SetDeliveryCost(double cost)
        {
            _order.SetDeliveryCost(cost);
        }

        public virtual double GetDeliveryCost()
        {
            return _order.GetDeliveryCost();
        }

        public virtual double GetTotalCost()
        {
            return _order.GetTotalCost();
        }

        public override string ToString()
        {
            return _order.ToString();
        }
    }
}
