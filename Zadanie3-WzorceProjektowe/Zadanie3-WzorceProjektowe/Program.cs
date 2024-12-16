using Zadanie3_WzorceProjektowe;
using Zadanie3_WzorceProjektowe.Staff;

Restaurant restaurant = new();

Cook cook1 = new();
Cook cook2 = new();

Waiter waiter = new Waiter();

restaurant.AddEmployee(cook1);
restaurant.AddEmployee(cook2);
restaurant.AddEmployee(waiter);


restaurant.AddOrder(new Order());
restaurant.AddOrder(new Order());
restaurant.AddOrder(new Order());
restaurant.AddOrder(new Order());


