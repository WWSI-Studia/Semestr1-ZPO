namespace RestaurantManagment.Meals
{
    class StandardMeal : Meal
    {
        public void SetMainCourse(StandardMainCourseOption mainCourseOption, double price)
        {
            MainCourse = new MealItem(mainCourseOption.ToString(), price);
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

    enum StandardMainCourseOption
    {
        Porkchop
    }

    enum StandardFirstSideDishOption
    {
        Potatoes
    }

    enum StandardSecondSideDishOption
    {
        Salad
    }
}
