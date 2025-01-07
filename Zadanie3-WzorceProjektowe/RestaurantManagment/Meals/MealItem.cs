namespace RestaurantManagment.Meals
{
    public class MealItem(string name, double price)
    {
        public string Name { get; } = name;
        public double Price { get; } = price;
    }
}