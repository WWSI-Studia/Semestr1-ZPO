using Moq;
using RestaurantManagment;
using RestaurantManagment.Meals;
using RestaurantManagment.Orders;
using RestaurantManagment.Orders.OrderDecorator;

namespace RestaurantManagmentTests
{
    [TestClass]
    public class PercentageTipOrderDecoratorTests
    {
        private Mock<Order> _mockOrder = null!;

        [TestInitialize]
        public void SetUp()
        {
            string name = "TestOrder";
            List<Meal> meals = [];
            DeliveryAddress? deliveryAddress = null;

            _mockOrder = new(name, meals, deliveryAddress);
            _mockOrder.Setup(o => o.GetTotalCost()).Returns(100);
        }

        [TestMethod]
        public void GetTotalCost_ShouldReturnCostIncreasedByTip()
        {
            PercentageTipOrderDecorator decoratedOrder = new(_mockOrder.Object, 15);

            double actualCost = decoratedOrder.GetTotalCost();

            Assert.AreEqual(115, actualCost);
        }

        [TestMethod]
        public void GetTotalCost_ShouldReturnCostIncreasedByMinimumTipWhenValueIsZero()
        {
            PercentageTipOrderDecorator decoratedOrder = new(_mockOrder.Object, 0);

            double actualCost = decoratedOrder.GetTotalCost();

            Assert.AreEqual(105, actualCost);
        }

        [TestMethod]
        public void GetTotalCost_ShouldReturnCostIncreasedByMinimumTipWhenValueIsNegative()
        {
            PercentageTipOrderDecorator decoratedOrder = new(_mockOrder.Object, -1);

            double actualCost = decoratedOrder.GetTotalCost();

            Assert.AreEqual(105, actualCost);

        }

        [TestMethod]
        public void GetTotalCost_ShouldReturnCostIncreasedByMinimumTipWhenValueIsMinimumNumber()
        {
            PercentageTipOrderDecorator decoratedOrder = new(_mockOrder.Object, double.MinValue);

            double actualCost = decoratedOrder.GetTotalCost();

            Assert.AreEqual(105, actualCost);

        }

        [TestMethod]
        public void Constructor_ShouldThrowErrorForTipEqualMaxNumber()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PercentageTipOrderDecorator(_mockOrder.Object, double.MaxValue));
        }

        [TestMethod]
        public void Constructor_ShouldThrowErrorForTipEqualPositiveInfinity()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PercentageTipOrderDecorator(_mockOrder.Object, double.PositiveInfinity));
        }

        [TestMethod]
        public void Constructor_ShouldThrowErrorForTipEqualNegativeInfinity()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PercentageTipOrderDecorator(_mockOrder.Object, double.NegativeInfinity));
        }
    }
}
