using Zadanie2_SOLID;

Console.WriteLine("\n\nSOLID exercise 1\n");
Master master = new();
master.SetInhabitants();

Console.WriteLine("\nList of inhabitants:\n");
master.Show();

Console.WriteLine("\nChange inhabitants role\n");
master.ChangeInhabitantRole(1, new Gardener());
master.ChangeInhabitantRole(2, new Knight("stick", "lizard"));
master.ChangeInhabitantRole(2, new Gardener());
master.ChangeInhabitantRole(3, new Knight("stick", "lizard"));
master.ChangeInhabitantRole(4, new Gardener());

Console.WriteLine("\nList of inhabitants:\n");
master.Show();

Console.WriteLine("\nPlaying:\n");
master.Play();
