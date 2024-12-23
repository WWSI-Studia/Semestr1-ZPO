namespace Zadanie3_WzorceProjektowe.Orders.OrderDecorator
{
    class PercentageDiscountOrderDecorator : OrderDecorator
    {
        private readonly double _percent;

        public PercentageDiscountOrderDecorator(IOrder order, double percent) : base(order)
        {
            if (percent < 1)
            {
                _percent = 1;
            }
            else if (percent > 100)
            {
                _percent = 100;
            }
            else
            {
                _percent = percent;
            }
        }

        public override double GetTotalCost()
        {
            double cost = base.GetTotalCost();

            cost -= cost * _percent / 100;

            return Math.Round(cost, 2);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nA discount was used for the ${_percent}% - cost after discount: {GetTotalCost()}";
        }
    }
}
