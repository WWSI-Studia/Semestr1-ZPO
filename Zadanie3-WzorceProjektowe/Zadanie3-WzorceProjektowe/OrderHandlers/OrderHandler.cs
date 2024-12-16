namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    abstract class OrderHandler : IOrderHandler
    {
        private IOrderHandler? _nextHandler;

        public IOrderHandler? SetNext(IOrderHandler? handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual Order? Handle(Order order, Restaurant restaurant)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(order, restaurant);
            }
            else
            {
                // Dodajemy zamówienie kolejny raz do kolejki, aby wykonać kolejny krok jego przetwarzania.
                restaurant.AddOrder(order);

                return order;
            }
        }
    }
}
