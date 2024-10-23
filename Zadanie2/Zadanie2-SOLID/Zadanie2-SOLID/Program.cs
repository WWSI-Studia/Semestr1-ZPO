using Zadanie2_SOLID;

Console.WriteLine("\n\nSOLID exercise 1\n");
Master master = new();
master.SetInhabitants();

Console.WriteLine("\nList of inhabitants:\n");
master.Show();

Console.WriteLine("\nChange inhabitants role\n");
master.ChangeRandomInhabitantRole(new Gardener());
master.ChangeRandomInhabitantRole(new Gardener());
master.ChangeRandomInhabitantRole(new Knight("stick", "lizard"));

Console.WriteLine("\nList of inhabitants:\n");
master.Show();

Console.WriteLine("\nPlaying:\n");
master.Play();
