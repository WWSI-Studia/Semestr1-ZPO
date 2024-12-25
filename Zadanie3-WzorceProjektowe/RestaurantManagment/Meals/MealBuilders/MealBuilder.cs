namespace RestaurantManagment.Meals.MealBuilders
{
    abstract class MealBuilder<T, U, W> : IMealBuilder<T, U, W>
    {
        protected Meal meal = new();

        public abstract void SetMainCourse(T mainCourse);
        public abstract void SetFirstSideDish(U firstSideDish);
        public abstract void SetSecondSideDish(W secondSideDish);

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
