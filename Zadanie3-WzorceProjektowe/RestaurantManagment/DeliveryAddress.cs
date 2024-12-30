namespace RestaurantManagment
{
    public class DeliveryAddress(double price, string city, string zipCode, string street, string? flatNumber = null)
    {
        public double Price { get; } = price;
        public string City { get; } = city;
        public string ZipCode { get; } = zipCode;
        public string Street { get; } = street;
        public string? FlatNumber { get; } = flatNumber;
    }
}
