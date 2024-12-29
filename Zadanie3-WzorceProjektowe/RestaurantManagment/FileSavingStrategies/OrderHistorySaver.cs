using RestaurantManagment.Orders;

namespace RestaurantManagment.FileSavingStrategies
{
    class OrderHistorySaver
    {
        private IFileSavingStrategy _fileSavingStrategy;

        public OrderHistorySaver(IFileSavingStrategy fileSavingStrategy)
        {
            _fileSavingStrategy = fileSavingStrategy;
        }

        public void SetStrategy(IFileSavingStrategy fileSavingStrategy)
        {
            _fileSavingStrategy = fileSavingStrategy;
        }

        public void SaveOrders(List<IOrder> orders, string filePath)
        {
            _fileSavingStrategy.Save(orders, filePath);
        }
    }
}
