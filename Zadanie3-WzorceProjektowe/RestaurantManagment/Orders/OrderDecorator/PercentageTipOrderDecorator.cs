namespace RestaurantManagment.Orders.OrderDecorator
{
    class PercentageTipOrderDecorator : OrderDecorator
    {
        private readonly double _percent;

        public PercentageTipOrderDecorator(IOrder order, double percent) : base(order)
        {
            if (percent < 5)
            {
                _percent = 5;
            }
            else
            {
                _percent = percent;
            }
        }

        public override double GetTotalCost()
        {
            double cost = base.GetTotalCost();

            cost += cost * _percent / 100;

            return Math.Round(cost, 2);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nA discount was used for the {_percent}% - cost after discount: {GetTotalCost()}";
        }
    }
}
