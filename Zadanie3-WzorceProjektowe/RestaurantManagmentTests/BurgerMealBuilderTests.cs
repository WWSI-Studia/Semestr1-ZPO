using RestaurantManagment.Meals;
using RestaurantManagment.Meals.MealBuilders;

namespace RestaurantManagmentTests
{
    [TestClass]
    public class BurgerMealBuilderTests
    {
        private BurgerMealBuilder _builder = null!;

        [TestInitialize]
        public void SetUp()
        {
            _builder = new BurgerMealBuilder();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _builder.Reset();
        }

        [TestMethod]
        public void Reset_ShouldResetMealBuilder()
        {
            _builder.SetDefaultMeal();

            _builder.Reset();
            BurgerMeal meal = _builder.GetMeal();

            Assert.IsNotNull(meal);
            Assert.IsNull(meal.MainCourse);
            Assert.IsNull(meal.FirstSideDish);
            Assert.IsNull(meal.SecondSideDish);
        }

        [TestMethod]
        public void BurgerMealBuilder_ShouldSetDefaultMealOptions()
        {
            _builder.SetDefaultMeal();
            var meal = _builder.GetMeal();

            Assert.AreEqual("Burger " + BurgerMainCourseOption.Standard.ToString(), meal.MainCourse.Name);
            Assert.AreEqual(BurgerFirstSideDishOption.Fries.ToString(), meal.FirstSideDish.Name);
            Assert.AreEqual(BurgerSecondSideDishOption.Salad.ToString(), meal.SecondSideDish.Name);
        }

        [TestMethod]
        public void BurgerMealBuilder_ShouldSetValidMealOptions()
        {
            _builder.SetMainCourse(BurgerMainCourseOption.Spicy);
            _builder.SetFirstSideDish();
            var meal = _builder.GetMeal();

            Assert.AreEqual("Burger " + BurgerMainCourseOption.Spicy.ToString(), meal.MainCourse.Name);
            Assert.AreEqual(BurgerFirstSideDishOption.Fries.ToString(), meal.FirstSideDish.Name);
            Assert.AreEqual(null, meal.SecondSideDish);
        }

        [TestMethod]
        public void SetMainCourse_ShouldFallbackToDefaultForInvalidOption()
        {
            _builder.SetMainCourse((BurgerMainCourseOption)999);
            var meal = _builder.GetMeal();

            Assert.AreEqual("Burger " + BurgerMainCourseOption.Standard.ToString(), meal.MainCourse.Name);
        }

        [TestMethod]
        public void SetFirstSideDish_ShouldFallbackToDefaultForInvalidOption()
        {
            _builder.SetFirstSideDish((BurgerFirstSideDishOption)999);
            var meal = _builder.GetMeal();

            Assert.AreEqual(BurgerFirstSideDishOption.Fries.ToString(), meal.FirstSideDish.Name);
        }

        [TestMethod]
        public void SetSecondSideDish_ShouldFallbackToDefaultForInvalidOption()
        {
            _builder.SetSecondSideDish((BurgerSecondSideDishOption)999);
            var meal = _builder.GetMeal();

            Assert.AreEqual(BurgerSecondSideDishOption.Salad.ToString(), meal.SecondSideDish.Name);
        }
    }
}