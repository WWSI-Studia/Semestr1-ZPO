using Zadanie3_WzorceProjektowe.Orders;

namespace Zadanie3_WzorceProjektowe.Staff
{
    interface IEmployee
    {
        public Task<IOrder> ProcessOrderAsync(IOrder order);
    }
}
