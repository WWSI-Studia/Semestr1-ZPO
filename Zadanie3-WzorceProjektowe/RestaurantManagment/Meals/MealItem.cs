namespace RestaurantManagment.Meals
{
    class MealItem(string name, double price)
    {
        public string Name { get; protected set; } = name;
        public double Price { get; protected set; } = price;
    }
}