using TinyPong.Exceptions;

namespace TinyPong.Tests
{
    [TestClass]
    public class ScreenFactoryTests
    {
        [TestMethod]
        public void ThrowInvalidScreenTypeExceptionTest()
        {
            // Arrange
            var tinyPong = new TinyPong();
            var screenFactory = new ScreenFactory(tinyPong);
            // Act
            Action act = () => screenFactory.CreateScreen((ScreenType) 99);
            // Assert
            Assert.ThrowsException<InvalidScreenTypeException>(act);
        }
    }
}