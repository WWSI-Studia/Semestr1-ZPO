namespace Zadanie3_WzorceProjektowe.Orders.OrderDecorator
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

            return cost;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nA discount was used for the amount of {_amount}PLN - cost after discount: {GetTotalCost()}";
        }
    }
}
