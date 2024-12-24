namespace RestaurantManagment.Meals.MealsBuilder
{
    abstract class MealBuilder : IMealBuilder
    {
        protected Meal meal = new();

        public abstract void SetMainCourse<T>(T mainCourse);
        public abstract void SetFirstSideDish<T>(T firstSideDish);
        public abstract void SetSecondSideDish<T>(T secondSideDish);

        public Meal Build()
        {
            return meal;
        }

        public void Reset()
        {
            meal = new();
        }
    }
}
