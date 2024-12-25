namespace RestaurantManagment.Meals.MealBuilders
{
    interface IMealBuilder<T, U, W>
    {
        public void SetMainCourse(T mainCourse);
        public void SetFirstSideDish(U firstSideDish);
        public void SetSecondSideDish(W secondSideDish);
        public Meal Build();
        public void Reset();
    }
}
