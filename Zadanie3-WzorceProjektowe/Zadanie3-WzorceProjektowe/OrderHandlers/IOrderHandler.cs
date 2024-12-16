namespace Zadanie3_WzorceProjektowe.OrderHandlers
{
    interface IOrderHandler
    {
        IOrderHandler? SetNext(IOrderHandler? order);
        Order? Handle(Order order, Restaurant restaurant);
    }
}
