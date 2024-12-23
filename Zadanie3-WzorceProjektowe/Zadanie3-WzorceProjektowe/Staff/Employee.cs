﻿using Zadanie3_WzorceProjektowe.Orders;

namespace Zadanie3_WzorceProjektowe.Staff
{
    abstract class Employee(string name) : IEmployee
    {
        protected readonly string _name = name;
        public bool IsBusy { get; private set; }

        public void MarkAsBusy() { IsBusy = true; }

        public void MarkAsNotBusy() { IsBusy = false; }

        public abstract Task<IOrder> ProcessOrderAsync(IOrder order);
    }
}
