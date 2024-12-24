using RestaurantManagment.OrderHandlers;
using RestaurantManagment.Orders;
using RestaurantManagment.Staff;

namespace RestaurantManagment
{
    class Restaurant
    {
        private readonly List<Cook> _cooks = [];
        private readonly List<Waiter> _waiters = [];
        private readonly Queue<IOrder> _orders = [];
        private readonly List<IOrder> _completedOrders = [];
        private readonly OrderHandler _orderHandler;

        public Restaurant(IOrderHandler? externalOrderHandler = null)
        {
            NewOrderHandler newOrderHandler = new NewOrderHandler();
            InKitchenOrderHandler inKitchenOrderHandler = new InKitchenOrderHandler();
            PreparedOrderHandler preparedOrderHandler = new PreparedOrderHandler();

            newOrderHandler.SetNext(inKitchenOrderHandler);
            inKitchenOrderHandler.SetNext(preparedOrderHandler);
            preparedOrderHandler.SetNext(externalOrderHandler);

            _orderHandler = newOrderHandler;
        }

        public void AddEmployee(Cook cook)
        {
            _cooks.Add(cook);
        }

        public void AddEmployee(Waiter waiter)
        {
            _waiters.Add(waiter);
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
