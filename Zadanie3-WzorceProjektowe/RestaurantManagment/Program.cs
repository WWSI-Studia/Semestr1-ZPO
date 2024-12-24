using RestaurantManagment;
using RestaurantManagment.Orders;
using RestaurantManagment.Orders.OrderDecorator;
using RestaurantManagment.Staff;

Restaurant restaurant = new();

Cook cook1 = new("Andrzej");
Cook cook2 = new("Beata");

Waiter waiter = new("Jan");
Waiter waiter2 = new("Karol");

restaurant.AddEmployee(cook1);
restaurant.AddEmployee(cook2);
restaurant.AddEmployee(waiter);
restaurant.AddEmployee(waiter2);

DeliveryAddress address = new("Warszawa");

IOrder[] orders = [
        new Order("Mielony"),
        new FreeDeliveryDiscountOrderDecorator(new Order("Schabowy", address)),
        new CashAmountDiscountOrderDecorator(new Order("Kurczak"), 10),
        new CashAmountTipOrderDecorator(new PercentageDiscountOrderDecorator(new Order("Sałatka", address), 50), 10),
    ];

foreach (IOrder order in orders)
{
    Console.WriteLine(order);
    Console.WriteLine();
    restaurant.AddOrder(order);
}

restaurant.StartWorking();

