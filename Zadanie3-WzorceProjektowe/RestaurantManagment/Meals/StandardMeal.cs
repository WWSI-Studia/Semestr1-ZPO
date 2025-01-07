namespace RestaurantManagment.Meals
{
    public class StandardMeal : Meal
    {
        public void SetMainCourse(StandardMainCourseOption mainCourse, double price)
        {
            MainCourse = new MealItem(mainCourse.ToString(), price);
        }

        public void SetFirstSideDish(StandardFirstSideDishOption firstSideDish, double price)
        {
            FirstSideDish = new MealItem(firstSideDish.ToString(), price);
        }

        public void SetSecondSideDish(StandardSecondSideDishOption secondSideDish, double price)
        {
            SecondSideDish = new MealItem(secondSideDish.ToString(), price);
        }
    }

    public enum StandardMainCourseOption
    {
        Porkchop,
        Chicken,
        Beef_Welington
    }

    public enum StandardFirstSideDishOption
    {
        Potatoes,
        Baked_Potatoes,
    }

    public enum StandardSecondSideDishOption
    {
        Salad,
        Asparagus
    }
}
