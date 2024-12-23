namespace Zadanie3_WzorceProjektowe.Orders.OrderDecorator
{
    class CashAmountTipOrderDecorator(IOrder order, double amount) : OrderDecorator(order)
    {
        private readonly double _amount = amount;

        public override double GetTotalCost()
        {
            double cost = base.GetTotalCost();

            cost += _amount;

            return cost;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nA tip was added for the amount of {_amount}PLN - cost after tip: {GetTotalCost()}";
        }
    }
}
