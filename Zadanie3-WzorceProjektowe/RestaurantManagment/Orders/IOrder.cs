using RestaurantManagment.Meals;

namespace RestaurantManagment.Orders
{
    interface IOrder
    {
        public string Name { get; }
        public OrderStatus Status { get; }
        public bool IsDelivery { get; }
        public DeliveryAddress? DeliveryAddress { get; }
        public void AddMeal(Meal meal);
        public List<Meal> GetMeals();
        public void SetOrderStatus(OrderStatus orderStatus);
        public void SetDeliveryCost(double cost);
        public double GetDeliveryCost();
        public double GetTotalCost();
        public string ToString();

    }
}
