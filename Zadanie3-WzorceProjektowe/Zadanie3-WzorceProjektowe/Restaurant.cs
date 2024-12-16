using Zadanie3_WzorceProjektowe.OrderHandlers;
using Zadanie3_WzorceProjektowe.Staff;

namespace Zadanie3_WzorceProjektowe
{
    class Restaurant
    {
        private readonly List<Cook> _cooks = [];
        private readonly List<Waiter> _waiters = [];
        private readonly Queue<Order> _orders = [];
        private readonly List<Order> _completedOrders = [];
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

        public void AddOrder(Order order)
        {
            if (order.Status == OrderStatus.Completed)
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
            return _waiters.FirstOrDefault(waiter => !waiter.IsBusy);
        }

        public void StartWorking()
        {
            while (_orders.Count > 0)
            {
                Order order = _orders.Dequeue();
                _orderHandler.Handle(order, this);
            }
        }
    }
}
