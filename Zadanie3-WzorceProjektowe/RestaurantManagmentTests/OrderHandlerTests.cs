using RestaurantManagment;
using RestaurantManagment.OrderHandlers;
using RestaurantManagment.Orders;
using RestaurantManagment.Staff;
using Telerik.JustMock;

namespace RestaurantManagmentTests
{
    [TestClass]
    public class OrderHandlerTests
    {
        [TestMethod]
        public async Task NewOrderHandler_ShouldCallGetAvailableWaiterOnceForNewOrderStatus_Async()
        {
            NewOrderHandler orderHandler = new();

            Order order = new("TestOrder", []);
            order.SetOrderStatus(OrderStatus.New);

            // Arrange
            var restaurantMock = Mock.Create<Restaurant>(Constructor.Mocked, Behavior.CallOriginal);

            Mock.Arrange(() => restaurantMock.GetAvailableWaiter()).DoNothing();
            Mock.Arrange(() => restaurantMock.AddOrder(order)).DoNothing();

            await orderHandler.HandleAsync(order, restaurantMock);

            Mock.Assert(() => restaurantMock.GetAvailableWaiter(), Occurs.Once());
        }

        [TestMethod]
        public async Task NewOrderHandler_ShouldAlwaysCallAddOrder_Async()
        {
            NewOrderHandler orderHandler = new();

            Order order = new("TestOrder", []);

            var restaurantMock = Mock.Create<Restaurant>(Constructor.Mocked, Behavior.CallOriginal);
            Mock.Arrange(() => restaurantMock.GetAvailableWaiter()).DoNothing();
            Mock.Arrange(() => restaurantMock.AddOrder(order)).DoNothing();

            order.SetOrderStatus(OrderStatus.New);
            await orderHandler.HandleAsync(order, restaurantMock);

            order.SetOrderStatus(OrderStatus.In_Kitchen);
            await orderHandler.HandleAsync(order, restaurantMock);

            order.SetOrderStatus(OrderStatus.In_Delivery);
            await orderHandler.HandleAsync(order, restaurantMock);

            Mock.Assert(() => restaurantMock.AddOrder(order), Occurs.Exactly(3));
        }

        [TestMethod]
        public async Task NewOrderHandler_ShouldProcessNewOrderWhenWaiterIsAvailable_Async()
        {
            NewOrderHandler orderHandler = new();

            Order order = new("TestOrder", []);
            order.SetOrderStatus(OrderStatus.New);

            var restaurantMock = Mock.Create<Restaurant>(Constructor.Mocked, Behavior.CallOriginal);
            var waiterMock = Mock.Create<Waiter>();

            Mock.Arrange(() => restaurantMock.GetAvailableWaiter()).Returns(waiterMock);
            Mock.Arrange(() => restaurantMock.AddOrder(order)).DoNothing();

            Mock.Arrange(() => waiterMock.ProcessOrderAsync(order)).ReturnsAsync(order);

            await orderHandler.HandleAsync(order, restaurantMock);

            Mock.Assert(() => restaurantMock.GetAvailableWaiter(), Occurs.Once());
            Mock.Assert(() => waiterMock.ProcessOrderAsync(order), Occurs.Once());

        }
    }
}