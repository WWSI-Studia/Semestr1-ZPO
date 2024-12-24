using RestaurantManagment;
using RestaurantManagment.Orders;
using RestaurantManagment.Orders.OrderDecorator;
using RestaurantManagment.Staff;

namespace OrderProcessing
{
    class Program
    {
        private static Cook[] PrepareCooks()
        {
            Cook[] employees =
            [
                new Cook("Andrzej"),
                new Cook("Beata"),
            ];

            foreach (var employee in employees)
            {
                Console.WriteLine(employee + "\n");
            }

            return employees;
        }

        private static Waiter[] PrepareWaiters()
        {
            Waiter[] employees =
            [
                new Waiter("Jan"),
                new Waiter("Karol"),
            ];

            foreach (var employee in employees)
            {
                Console.WriteLine(employee + "\n");
            }

            return employees;
        }

        private static IOrder[] PrepareOrders()
        {
            DeliveryAddress address = new("Warszawa");

            IOrder[] orders = [
                    new Order("Mielony"),
                    new FreeDeliveryDiscountOrderDecorator(new Order("Schabowy", address)),
                    new CashAmountDiscountOrderDecorator(new Order("Kurczak"), 10),
                    new CashAmountTipOrderDecorator(new PercentageDiscountOrderDecorator(new Order("Sałatka", address), 50), 10),
                ];

            foreach (var order in orders)
            {
                Console.WriteLine(order + "\n");
            }

            return orders;
        }



        static void Main(string[] args)
        {

            Console.WriteLine("-------------CREATING_EMPLOYEES----------------------");
            Cook[] cooks = PrepareCooks();
            Waiter[] waiters = PrepareWaiters();

            Console.WriteLine("-------------CREATING_ORDERS----------------------");
            IOrder[] orders = PrepareOrders();

            Console.WriteLine("-------------CREATING_RESTAURANT----------------------");
            Restaurant restaurant = Restaurant.GetInstance();

            foreach (var cook in cooks)
            {
                restaurant.AddEmployee(cook);
            }

            foreach (var waiter in waiters)
            {
                restaurant.AddEmployee(waiter);
            }

            foreach (var order in orders)
            {
                restaurant.AddOrder(order);
            }

            Console.WriteLine("-------------PROCESSING_ORDERS----------------------");
            restaurant.StartWorking();
        }
    }
}
