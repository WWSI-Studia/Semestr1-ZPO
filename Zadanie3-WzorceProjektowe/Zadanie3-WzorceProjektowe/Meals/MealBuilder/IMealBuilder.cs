namespace Zadanie3_WzorceProjektowe.Meals.MealsBuilder
{
    interface IMealBuilder
    {
        public void SetMainCourse<T>(T mainCourse);
        public void SetFirstSideDish<T>(T firstSideDish);
        public void SetSecondSideDish<T>(T secondSideDish);
        public Meal Build();
        public void Reset();
    }
}
