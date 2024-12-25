using RestaurantManagment.Orders;

namespace RestaurantManagment.OrderHandlers
{
    abstract class OrderHandler : IOrderHandler
    {
        protected readonly object _lock = new();
        private IOrderHandler? _nextHandler;

        public IOrderHandler? SetNext(IOrderHandler? handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual async Task<IOrder?> HandleAsync(IOrder order, Restaurant restaurant)
        {
            if (_nextHandler != null)
            {
                return await _nextHandler.HandleAsync(order, restaurant);
            }
            else
            {
                // Dodajemy zamówienie kolejny raz do kolejki, aby wykonać kolejny krok jego przetwarzania.
                // Ukończone zamówienie trafi do listy ukończonych zamówień
                restaurant.AddOrder(order);

                return order;
            }
        }
    }
}
