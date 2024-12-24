using RestaurantManagment.OrderHandlers;
using RestaurantManagment.Orders;
using RestaurantManagment.Staff;

namespace RestaurantManagment
{
    class Restaurant
    {
        private static Restaurant? _restaurant;
        private readonly List<Cook> _cooks = [];
        private readonly List<Waiter> _waiters = [];
        private readonly Queue<IOrder> _orders = [];
        private readonly List<IOrder> _completedOrders = [];
        private readonly OrderHandler _orderHandler;

        private Restaurant(IOrderHandler? externalOrderHandler = null)
        {
            NewOrderHandler newOrderHandler = new();
            InKitchenOrderHandler inKitchenOrderHandler = new();
            PreparedOrderHandler preparedOrderHandler = new();

            newOrderHandler.SetNext(inKitchenOrderHandler);
            inKitchenOrderHandler.SetNext(preparedOrderHandler);
            preparedOrderHandler.SetNext(externalOrderHandler);

            _orderHandler = newOrderHandler;
            _restaurant = this;
        }

        public static Restaurant GetInstance(IOrderHandler? externalOrderHandler = null)
        {
            if (_restaurant != null)
            {
                return _restaurant;
            }

            return new Restaurant(externalOrderHandler);
        }

        public void AddEmployee(Cook cook)
        {
            _cooks.Add(cook);
            LogAddedEmployee(cook);
        }

        public void AddEmployee(Waiter waiter)
        {
            _waiters.Add(waiter);
            LogAddedEmployee(waiter);
        }

        private static void LogAddedEmployee(IEmployee employee)
        {
            Console.WriteLine(employee.ToString() + " came to work.");
        }

        public void AddOrder(IOrder order)
        {
            if (order.GetOrderStatus() == OrderStatus.Completed)
            {
                _completedOrders.Add(order);
            }
            else
            {
                // TODO odrzucać zamówienia z dostawą jeżeli nie ma dostawcy
                _orders.Enqueue(order);
            }
        }

        public Cook? GetAvailableCook()
        {
            return _cooks.FirstOrDefault(cook => !cook.IsBusy);
        }

        public Waiter? GetAvailableWaiter()
        {
            Waiter? waiter = _waiters.FirstOrDefault(waiter => !waiter.IsBusy);
            return waiter;
        }

        public void StartWorking()
        {
            List<Task> tasks = [];

            while (_orders.Count > 0 || tasks.Any(t => !t.IsCompleted))
            {
                for (int i = 0; i < _orders.Count; i++)
                {
                    IOrder order = _orders.Dequeue();
                    Task task = _orderHandler.HandleAsync(order, this);
                    tasks.Add(task);
                }

                // Usuwamy przetworzone stany zamówienia
                tasks.RemoveAll(t => t.IsCompleted);

                // Czekamy chwilę przed kolejną iteracją, aby pracownicy mogli skończyć swoje obecne zadania
                Task.Delay(1000).Wait();
            }
        }
    }
}
