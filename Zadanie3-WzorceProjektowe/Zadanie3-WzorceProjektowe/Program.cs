﻿using Zadanie3_WzorceProjektowe;
using Zadanie3_WzorceProjektowe.Staff;

Restaurant restaurant = new();

Cook cook1 = new("Andrzej");
Cook cook2 = new("Beata");

Waiter waiter = new("Jan");
Waiter waiter2 = new("Karol");

restaurant.AddEmployee(cook1);
restaurant.AddEmployee(cook2);
restaurant.AddEmployee(waiter);
restaurant.AddEmployee(waiter2);

DeliveryAddress address = new("Warszawa");

restaurant.AddOrder(new Order("Mielony"));
restaurant.AddOrder(new Order("Schabowy", address));
restaurant.AddOrder(new Order("Kurczak"));
restaurant.AddOrder(new Order("Sałatka", address));

restaurant.StartWorking();