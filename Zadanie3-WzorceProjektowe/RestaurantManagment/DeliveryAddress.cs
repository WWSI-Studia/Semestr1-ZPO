namespace RestaurantManagment
{
    public class DeliveryAddress(string city, double price)
    {
        public readonly string city = city;
        public double Price { get; } = price;
    }
}
