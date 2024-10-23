namespace Zadanie2_SOLID
{
    class Inhabitant(string name, string gender, string fatherName, string motherName, IRole role) : IPerson
    {
        public string Name => name;
        public string Gender => gender;
        public string FatherName => fatherName;
        public string MotherName => motherName;
        public IRole Role { get; set; } = role;

        public string Describe()
        {
            return string.Format(
               "{0} {1}, {2} of {3} and {4}. {5}",
              this.Role.NameOfTheRole,
              this.Name,
              this.Gender == "m" ? "son" : "daughter",
              this.FatherName,
              this.MotherName,
              this.Role.Describe());
        }

        public string Play()
        {
            return this.Role.ExecuteRoleAction();
        }

        public void ChangeRole(IRole role)
        {
            if (this.Role.GetType() == role.GetType())
            {
                Console.WriteLine("Inhabitant already has selected role.");
            }
            else
            {
                this.Role = role;
                Console.WriteLine("Successfully changed inhabitant role: " + this.Describe());
            }
        }
    }
}