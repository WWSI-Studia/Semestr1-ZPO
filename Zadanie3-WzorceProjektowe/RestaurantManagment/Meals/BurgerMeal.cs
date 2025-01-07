namespace RestaurantManagment.Meals
{
    public class BurgerMeal : Meal
    {
        public void SetMainCourse(BurgerMainCourseOption mainCourse, double price)
        {
            MainCourse = new MealItem("Burger " + mainCourse.ToString(), price);
        }

        public void SetFirstSideDish(BurgerFirstSideDishOption firstSideDish, double price)
        {
            FirstSideDish = new MealItem(firstSideDish.ToString(), price);
        }

        public void SetSecondSideDish(BurgerSecondSideDishOption secondSideDish, double price)
        {
            SecondSideDish = new MealItem(secondSideDish.ToString(), price);
        }
    }

    public enum BurgerMainCourseOption
    {
        Standard,
        Spicy
    }

    public enum BurgerFirstSideDishOption
    {
        Fries,
        Curly_Fries,
        Corn
    }

    public enum BurgerSecondSideDishOption
    {
        Salad,
        Coleslaw
    }
}
