namespace Zadanie3_WzorceProjektowe.Staff
{
    class Waiter : Employee
    {
        public override Order ProcessOrder(Order order)
        {
            IsBusy = true;
            // TODO w zależności czy przyjmuje czy zanosi
            Console.WriteLine("Waiter passes order to the kitchen");

            //await Task.Delay(1000);
            // TODO czekanie

            Console.WriteLine("Waiter is available again");
            IsBusy = false;

            return order;
        }
    }
}