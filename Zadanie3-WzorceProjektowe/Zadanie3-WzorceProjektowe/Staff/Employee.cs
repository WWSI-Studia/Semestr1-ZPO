namespace Zadanie3_WzorceProjektowe.Staff
{
    abstract class Employee : IEmployee
    {
        public bool IsBusy { get; protected set; }

        public abstract Order ProcessOrder(Order order);
    }
}
