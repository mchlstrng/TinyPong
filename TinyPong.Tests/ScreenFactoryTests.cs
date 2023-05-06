using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            void Act() => screenFactory.CreateScreen((ScreenType)99);
            // Assert
            Assert.ThrowsException<InvalidScreenTypeException>(Act);
        }

        [TestMethod]
        public void CreateMainMenuScreenTest()
        {
            // Arrange
            var tinyPong = new TinyPong();

            var contentManagerMock = new Mock<IContentManager>();
            tinyPong.ContentManager = contentManagerMock.Object;

            var screenFactory = new ScreenFactory(tinyPong);
            // Act
            var mainMenuScreen = screenFactory.CreateScreen(ScreenType.MainMenu);
            // Assert
            Assert.IsNotNull(mainMenuScreen);

        }

    }
}