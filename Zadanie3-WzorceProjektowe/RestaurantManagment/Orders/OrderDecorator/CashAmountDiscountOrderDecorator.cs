namespace RestaurantManagment.Orders.OrderDecorator
{
    class CashAmountTipOrderDecorator(IOrder order, double amount) : OrderDecorator(order)
    {
        private readonly double _amount = amount;

        public override double GetTotalCost()
        {
            double cost = base.GetTotalCost();

            cost += _amount;

            return Math.Round(cost, 2);
        }

        public override string ToString()
        {
            return base.ToString() + $"A tip was added for the amount of {_amount}PLN - cost after tip: {GetTotalCost()}\n";
        }
    }
}
