namespace Zadanie2_SOLID
{
    class Gardener() : IRole
    {
        public static double NICE_WEATHER_PROBABILITY = 0.75;
        public string NameOfTheRole => "Gardener";
        private int NumberOfPlantedTrees { get; set; } = 0;
        private Random Random { get; set; } = new();

        public string Describe()
        {
            return string.Format(
               "Planted {0} trees. ",
              this.NumberOfPlantedTrees);
        }
        public string ExecuteRoleAction()
        {
            if (this.Random.NextDouble() < NICE_WEATHER_PROBABILITY)
            {
                this.NumberOfPlantedTrees++;
                return "Planting a tree...";
            }
            else
            {
                return "Looking at trees growing in the rain...";
            }
        }
    }
}
