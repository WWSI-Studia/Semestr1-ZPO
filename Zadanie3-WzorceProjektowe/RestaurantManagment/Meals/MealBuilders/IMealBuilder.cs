namespace RestaurantManagment.Meals.MealBuilders
{
    interface IMealBuilder<T, U, W>
    {
        public void SetDefaultMeal();
        public void SetMainCourse(T mainCourse);
        public void SetFirstSideDish(U firstSideDish);
        public void SetSecondSideDish(W secondSideDish);
        public void Reset();
    }
}
