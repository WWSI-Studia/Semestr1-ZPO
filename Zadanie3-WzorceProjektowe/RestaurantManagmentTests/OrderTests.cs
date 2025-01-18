using Moq;
using RestaurantManagment;
using RestaurantManagment.Meals;
using RestaurantManagment.Orders;

namespace RestaurantManagmentTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void ShouldHaveValidListOfMeals()
        {
            Mock<Meal> mealMock = new();
            List<Meal> meals = [mealMock.Object];

            Order order = new("TestOrder", meals);

            List<Meal> returnedMeals = order.GetMeals();

            Assert.AreEqual(1, returnedMeals.Count);
            Assert.AreEqual(mealMock.Object, returnedMeals.First());
        }

        [TestMethod]
        public void ShouldHaveNewOrderStatus()
        {
            Order order = new("TestOrder", []);

            Assert.AreEqual(OrderStatus.New, order.Status);
        }

        [TestMethod]
        public void GetTotalCost_ShouldCallGetTotalCostForEveryMeal()
        {
            Mock<Meal> mealMock1 = new();
            Mock<Meal> mealMock2 = new();
            Mock<Meal> mealMock3 = new();

            List<Meal> meals = [mealMock1.Object, mealMock2.Object, mealMock3.Object];

            Order order = new("TestOrder", meals);

            order.GetTotalCost();

            mealMock1.Verify(m => m.GetTotalCost(), Times.Once());
            mealMock2.Verify(m => m.GetTotalCost(), Times.Once());
            mealMock3.Verify(m => m.GetTotalCost(), Times.Once());
        }

        [TestMethod]
        public void GetTotalCost_ShouldReturnValidTotalCost()
        {
            Mock<Meal> mealMock1 = new();
            mealMock1.Setup(m => m.GetTotalCost()).Returns(10);
            Mock<Meal> mealMock2 = new();
            mealMock2.Setup(m => m.GetTotalCost()).Returns(30.6242);
            Mock<Meal> mealMock3 = new();
            mealMock3.Setup(m => m.GetTotalCost()).Returns(20.99);

            List<Meal> meals = [mealMock1.Object, mealMock2.Object, mealMock3.Object];

            Order order = new("TestOrder", meals);

            double actualCost = order.GetTotalCost();

            double expectedCost = Math.Round(10 + 30.6242 + 20.99, 2);
            Assert.AreEqual(expectedCost, actualCost, "Total cost is incorrect.");
        }

        [TestMethod]
        public void GetTotalCost_ShouldIncludeDeliveryCost()
        {
            Mock<Meal> mealMock1 = new();
            mealMock1.Setup(m => m.GetTotalCost()).Returns(10);
            Mock<Meal> mealMock2 = new();
            mealMock2.Setup(m => m.GetTotalCost()).Returns(20);

            List<Meal> meals = [mealMock1.Object, mealMock2.Object];

            DeliveryAddress deliveryAddress = new(5, "TestCity", "TestZipCode", "TestStreet");


            Order order = new("TestOrder", meals, deliveryAddress);

            double actualCost = order.GetTotalCost();

            Assert.AreEqual(35, actualCost, "Total cost with delivery is incorrect.");
        }

        [TestMethod]
        public void SetDeliveryCost_ShouldUpdateDeliveryCost()
        {
            List<Meal> meals = [];
            DeliveryAddress deliveryAddress = new(5, "TestCity", "TestZipCode", "TestStreet");

            Order order = new("TestOrder", meals, deliveryAddress);

            order.SetDeliveryCost(10);
            double actualCost = order.GetDeliveryCost();

            Assert.AreEqual(10, actualCost, "Delivery cost after update is incorrect.");
        }
    }
}