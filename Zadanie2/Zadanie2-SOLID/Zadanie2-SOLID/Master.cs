﻿namespace Zadanie2_SOLID
{
    internal class Master
    {
        private List<IPerson> ListOfInhabitants { get; set; } = [];

        public void Show()
        {
            foreach (Inhabitant inihabitant in ListOfInhabitants)
            {
                Console.WriteLine(inihabitant.Describe());
            }
        }

        public void Play()
        {
            for (int i = 0; i < 10; i++)
            {
                Random random = new();
                IPerson inhabitant = this.ListOfInhabitants[random.Next(this.ListOfInhabitants.Count)];
                Console.WriteLine(inhabitant.Describe());

                while (random.NextDouble() < 0.75)
                {
                    Console.WriteLine(inhabitant.Play());
                }
            }
        }

        public void SetInhabitants()
        {
            this.ListOfInhabitants.Add(new Inhabitant("Slenderwillow", "f", "Oldoak", "Sunnydaisy", new Gardener()));
            this.ListOfInhabitants.Add(new Inhabitant("Quickhand", "m", "Bravedeed", "Sunbell", new Knight("sword", "horse")));
            this.ListOfInhabitants.Add(new Inhabitant("Truefriend", "m", "Highspirit", "Mistymorning", new Knight("spear", "dragon")));
            this.ListOfInhabitants.Add(new Inhabitant("Greenleaf", "m", "Brownleaf", "Goldendaisy", new Gardener()));
        }

        public void ChangeInhabitantRole(int inhabitantIndex, IRole role)
        {
            if (inhabitantIndex < 0 || inhabitantIndex >= this.ListOfInhabitants.Count)
            {
                Console.WriteLine("Incorrect index.");
            }
            else
            {
                IPerson inhabitant = this.ListOfInhabitants[inhabitantIndex];
                inhabitant.ChangeRole(role);
            }
        }
    }
}

