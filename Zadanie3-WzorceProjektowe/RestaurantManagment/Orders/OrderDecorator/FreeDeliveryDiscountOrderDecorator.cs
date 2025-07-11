﻿namespace RestaurantManagment.Orders.OrderDecorator
{
    public class FreeDeliveryDiscountOrderDecorator : OrderDecorator
    {
        public FreeDeliveryDiscountOrderDecorator(IOrder order) : base(order)
        {
            SetDeliveryCost(0);
        }

        public override string ToString()
        {
            return base.ToString() + $"A discount for free delivery was used - cost after discount: {GetTotalCost()}\n";
        }
    }
}
