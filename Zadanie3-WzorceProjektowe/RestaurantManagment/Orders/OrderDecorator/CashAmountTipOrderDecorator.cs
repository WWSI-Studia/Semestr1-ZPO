namespace RestaurantManagment.Orders.OrderDecorator
{
    class CashAmountDiscountOrderDecorator(IOrder order, double amount) : OrderDecorator(order)
    {
        private readonly double _amount = amount;

        public override double GetTotalCost()
        {
            double cost = base.GetTotalCost();

            cost -= _amount;
            if (cost < 0)
            {
                cost = 0;
            }

            return Math.Round(cost, 2);
        }

        public override string ToString()
        {
            return base.ToString() + $"A discount was used for the amount of {_amount}PLN - cost after discount: {GetTotalCost()}\n";
        }
    }
}
