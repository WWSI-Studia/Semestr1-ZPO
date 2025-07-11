﻿namespace RestaurantManagment.Orders.OrderDecorator
{
    public class PercentageDiscountOrderDecorator : OrderDecorator
    {
        private readonly double _percent;

        public PercentageDiscountOrderDecorator(IOrder order, double percent) : base(order)
        {
            if (double.IsInfinity(percent) || percent == double.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(percent));
            }

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
            return base.ToString() + $"A discount was used for the {_percent}% - cost after discount: {GetTotalCost()}\n";
        }
    }
}
