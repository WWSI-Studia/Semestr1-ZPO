namespace Zadanie3_WzorceProjektowe.Staff
{
    class Cook : Employee
    {
        public override Order ProcessOrder(Order order)
        {
            IsBusy = true;
            Console.WriteLine("Cook is preparing a meal");

            // TODO czekanie


            Console.WriteLine("Cook is available again");
            IsBusy = false;

            return order;
        }
    }
}
