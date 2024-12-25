using RestaurantManagment;
using RestaurantManagment.Meals;
using RestaurantManagment.Meals.MealBuilders;
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

        private static Deliveryman[] PrepareDeliverymans()
        {
            Deliveryman[] employees =
            [
                new Deliveryman("Rafał"),
            ];

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            return employees;
        }

        private static IOrder[] PrepareOrders()
        {
            MealDirector director = new();

            List<Meal> meals1 = [
                    director.CreateDefaultStandardMeal(),
                    director.CreateDefaultBurgerMeal()
                ];

            List<Meal> meals2 = [
                    director.CreateDefaultStandardMeal(),
                    director.CreateDefaultBurgerMeal()
                ];

            List<Meal> meals3 = [
                    director.CreateDefaultStandardMeal(),
                    director.CreateDefaultBurgerMeal()
                ];
            List<Meal> meals4 = [
                    director.CreateDefaultStandardMeal(),
                    director.CreateDefaultBurgerMeal()
                ];

            DeliveryAddress address1 = new("Warszawa", 10);
            DeliveryAddress address2 = new("Wrocław", 7.77);

            IOrder order1 = new Order("First", meals1);
            IOrder order2 = new FreeDeliveryDiscountOrderDecorator(new Order("Second", meals2, address1));
            IOrder order3 = new CashAmountDiscountOrderDecorator(new Order("Third", meals3), 10);
            IOrder order4 = new CashAmountTipOrderDecorator(new PercentageDiscountOrderDecorator(new Order("Fourth", meals4, address2), 50), 10);

            IOrder[] orders = [
                    order1,
                    order2,
                    order3,
                    order4,
                ];

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            return orders;
        }



        static void Main(string[] args)
        {

            Console.WriteLine("-------------CREATING_EMPLOYEES---------------------");
            Cook[] cooks = PrepareCooks();
            Waiter[] waiters = PrepareWaiters();
            Deliveryman[] deliverymans = PrepareDeliverymans();

            Console.WriteLine("-------------CREATING_ORDERS------------------------");
            IOrder[] orders = PrepareOrders();

            Console.WriteLine("-------------CREATING_RESTAURANT--------------------");
            Restaurant restaurant = Restaurant.GetInstance();

            foreach (var cook in cooks)
            {
                restaurant.AddEmployee(cook);
            }

            foreach (var waiter in waiters)
            {
                restaurant.AddEmployee(waiter);
            }

            foreach (var deliveryman in deliverymans)
            {
                restaurant.AddEmployee(deliveryman);
            }

            foreach (var order in orders)
            {
                restaurant.AddOrder(order);
            }

            Console.WriteLine("-------------PROCESSING_ORDERS----------------------");
            restaurant.StartWorking();

            Console.WriteLine("-------------LISTING_COMPLETED_ORDERS---------------");
            // TODO
        }
    }
}
