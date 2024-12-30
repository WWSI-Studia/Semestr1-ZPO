using RestaurantManagment.FileSavingStrategies;
using RestaurantManagment.Meals;
using RestaurantManagment.Meals.MealBuilders;
using RestaurantManagment.Orders;
using RestaurantManagment.Orders.OrderDecorator;
using RestaurantManagment.Staff;

namespace RestaurantManagment
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
            Meal meal1, meal2, meal3;
            MealDirector director = new();
            BurgerMealBuilder burgerMealBuilder = new();
            StandardMealBuilder standardMealBuilder = new();

            director.CreateDefaultMeal(standardMealBuilder);
            meal1 = standardMealBuilder.GetMeal();
            director.CreateDefaultMeal(burgerMealBuilder);
            meal2 = burgerMealBuilder.GetMeal();

            List<Meal> meals1 = [meal1, meal2];

            director.CreateCustomMeal(burgerMealBuilder, BurgerMainCourseOption.Standard);
            meal1 = burgerMealBuilder.GetMeal();

            List<Meal> meals2 = [meal1];

            director.CreateCustomMeal(burgerMealBuilder, BurgerMainCourseOption.Spicy, BurgerFirstSideDishOption.Fries);
            meal1 = burgerMealBuilder.GetMeal();
            director.CreateCustomMeal(burgerMealBuilder, BurgerMainCourseOption.Standard);
            meal2 = burgerMealBuilder.GetMeal();

            List<Meal> meals3 = [meal1, meal2];

            director.CreateCustomMeal(standardMealBuilder, StandardMainCourseOption.Porkchop, StandardFirstSideDishOption.Potatoes, StandardSecondSideDishOption.Salad);
            meal1 = standardMealBuilder.GetMeal();
            director.CreateCustomMeal(standardMealBuilder, StandardMainCourseOption.Beef_Welington, StandardFirstSideDishOption.Baked_Potatoes, StandardSecondSideDishOption.Salad);
            meal2 = standardMealBuilder.GetMeal();
            director.CreateCustomMeal(standardMealBuilder, StandardMainCourseOption.Porkchop, null, StandardSecondSideDishOption.Asparagus);
            meal3 = standardMealBuilder.GetMeal();

            List<Meal> meals4 = [meal1, meal2, meal3];

            DeliveryAddress address1 = new(10, "Warszawa", "00-169", "Jozefa Lewartowskiego", "17");
            DeliveryAddress address2 = new(7.77, "Warszawa", "00-116", "Aleja Jana Pawła II", "18/33");

            IOrder order1 = new Order("First", meals1);
            IOrder order2 = new FreeDeliveryDiscountOrderDecorator(new Order("Second", meals2, address1));
            IOrder order3 = new CashAmountDiscountOrderDecorator(new Order("Third", meals3), 10);
            IOrder order4 = new CashAmountTipOrderDecorator(new PercentageDiscountOrderDecorator(new Order("Fourth", meals4, address2), 30), 10);

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

            Console.WriteLine("\n-------------CREATING_ORDERS------------------------");

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

            Console.WriteLine("\n-------------PROCESSING_ORDERS----------------------");
            restaurant.StartWorking();

            Console.WriteLine("\n-------------SAVING_COMPLETED_ORDERS----------------");

            OrderHistorySaver orderHistorySaver = new(new CsvFileSavingStrategy());

            orderHistorySaver.SaveOrders(restaurant.GetCompletedOrders(), "orders.csv");
            Console.WriteLine("Completed orders saved in csv file");

            orderHistorySaver.SetStrategy(new TxtFileSavingStrategy());

            orderHistorySaver.SaveOrders(restaurant.GetCompletedOrders(), "orders.txt");
            Console.WriteLine("Completed orders saved in txt file");
        }
    }
}
