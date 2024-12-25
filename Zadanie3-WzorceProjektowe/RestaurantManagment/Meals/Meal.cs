using System.Text;

namespace RestaurantManagment.Meals
{
    class Meal
    {
        public MealItem? MainCourse { get; set; }
        public MealItem? FirstSideDish { get; set; }
        public MealItem? SecondSideDish { get; set; }

        public double GetTotalCost()
        {
            double totalCost = 0;

            if (MainCourse != null)
            {
                totalCost += MainCourse.Price;
            }

            if (FirstSideDish != null)
            {
                totalCost += FirstSideDish.Price;
            }

            if (SecondSideDish != null)
            {
                totalCost += SecondSideDish.Price;
            }

            return Math.Round(totalCost, 2);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            if (MainCourse == null)
            {
                return "Incorrect Meal";
            }

            stringBuilder.Append(MainCourse.Name);

            if (FirstSideDish != null)
            {
                stringBuilder.Append($" with {FirstSideDish.Name}");
                if (SecondSideDish != null)
                {
                    stringBuilder.Append($" and {SecondSideDish.Name}");
                }
            }
            else if (SecondSideDish != null)
            {
                stringBuilder.Append($" with {SecondSideDish.Name}");
            }

            stringBuilder.Append($" {GetTotalCost()}PLN");

            return stringBuilder.ToString();
        }
    }
}
