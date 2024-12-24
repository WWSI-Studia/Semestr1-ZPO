using RestaurantManagment;
using RestaurantManagment.Meals;
using RestaurantManagment.Meals.MealBuilder;
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
                Console.WriteLine(employee);
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
                Console.WriteLine(employee);
            }

            return employees;
        }

        private static IOrder[] PrepareOrders()
        {
            DeliveryAddress address = new("Warszawa");
            MealDirector director = new MealDirector();

            List<Meal> meals1 = [
                    director.CreateDefaultStandardMeal(),
                    director.CreateDefaultBurgerMeal()
                ];

            Console.WriteLine(meals1);
            Console.WriteLine(meals1[0]);
            Console.WriteLine(meals1);

            IOrder order1 = new Order("Mielony", meals1);
            IOrder order2 = new FreeDeliveryDiscountOrderDecorator(new Order("Schabowy", meals1, address));
            IOrder order3 = new CashAmountDiscountOrderDecorator(new Order("Kurczak", meals1), 10);
            IOrder order4 = new CashAmountTipOrderDecorator(new PercentageDiscountOrderDecorator(new Order("Sałatka", meals1, address), 50), 10);

            IOrder[] orders = [
                    order1,
                    order2,
                    order3,
                    order4,
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
