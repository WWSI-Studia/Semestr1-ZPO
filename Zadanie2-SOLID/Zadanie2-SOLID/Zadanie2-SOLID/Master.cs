namespace Zadanie2_SOLID
{
    class Master
    {
        private List<IPerson> ListOfPersons { get; set; } = [];

        public void Show()
        {
            foreach (IPerson inihabitant in ListOfPersons)
            {
                Console.WriteLine(inihabitant.Describe());
            }
        }

        public void Play()
        {
            for (int i = 0; i < 10; i++)
            {
                Random random = new();
                IPerson inhabitant = this.ListOfPersons[random.Next(this.ListOfPersons.Count)];
                Console.WriteLine(inhabitant.Describe());

                while (random.NextDouble() < 0.75)
                {
                    Console.WriteLine(inhabitant.Play());
                }
            }
        }

        public void SetInhabitants()
        {
            this.ListOfPersons.Add(new Inhabitant("Slenderwillow", "f", "Oldoak", "Sunnydaisy", new Gardener()));
            this.ListOfPersons.Add(new Inhabitant("Quickhand", "m", "Bravedeed", "Sunbell", new Knight("sword", "horse")));
            this.ListOfPersons.Add(new Inhabitant("Truefriend", "m", "Highspirit", "Mistymorning", new Knight("spear", "dragon")));
            this.ListOfPersons.Add(new Inhabitant("Greenleaf", "m", "Brownleaf", "Goldendaisy", new Gardener()));
        }

        public void ChangeInhabitantRole(int personIndex, IRole role)
        {
            if (personIndex < 0 || personIndex >= this.ListOfPersons.Count)
            {
                Console.WriteLine("Incorrect index.");
            }
            else
            {
                IPerson inhabitant = this.ListOfPersons[personIndex];
                inhabitant.ChangeRole(role);
            }
        }
    }
}

