namespace Zadanie2_SOLID
{
    class Knight(string weapon, string mount, double strength = 1) : IRole
    {
        public string NameOfTheRole => "Knight";
        private string Weapon { get; set; } = weapon;
        private string Mount { get; set; } = mount;
        private double Strength { get; set; } = strength;


        public string Describe()
        {
            return string.Format(
               "Fights using a {0} rides on a {1}. ",
              this.Weapon,
              this.Mount,
              this.Strength > 0 ? "Can fight" : "Needs a rest");
        }

        public string ExecuteRoleAction()
        {
            if (this.Strength <= 0)
            {
                this.Strength = 1.0;
                return "Resting...";
            }

            this.Strength -= 0.25;
            return "Figting...";
        }
    }
}