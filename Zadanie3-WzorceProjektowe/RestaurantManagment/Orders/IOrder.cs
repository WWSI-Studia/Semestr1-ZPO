using RestaurantManagment.Meals;

namespace RestaurantManagment.Orders
{
    interface IOrder
    {
        public bool IsDelivery { get; }
        public void AddMeal(Meal meal);
        public List<Meal> GetMeals();
        public void SetOrderStatus(OrderStatus orderStatus);
        public OrderStatus GetOrderStatus();
        public void SetDeliveryCost(double cost);
        public double GetDeliveryCost();
        public double GetTotalCost();
        public string ToString();

    }
}
