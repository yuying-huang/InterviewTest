using InterviewTestMid;
using Moq;
using Xunit;

namespace InterviewTestMid.Tests
{
    public class LoggerMockTests
    {
        [Fact]
        public void WriteLogMessage_Mocked_Success_CallsWithExpectedMessage()
        {
            // Arrange: 
            var mockLogger = new Mock<ILogger>();

            // Act: 
            mockLogger.Object.WriteLogMessage("Test message");

            // Assert: 
            mockLogger.Verify(
                logger => logger.WriteLogMessage("Test message"),
                Times.Once);
        }

        [Fact]
        public void WriteLogMessage_Mocked_ThrowsException_PropagatesToCaller()
        {
            // Arrange: 
            var mockLogger = new Mock<ILogger>();
            mockLogger
                .Setup(logger => logger.WriteLogMessage(It.IsAny<string>()))
                .Throws(new ArgumentException("Simulated failure"));

            // Act + Assert: 
            var exception = Assert.Throws<ArgumentException>(
                () => mockLogger.Object.WriteLogMessage("Any message"));

            Assert.Equal("Simulated failure", exception.Message);
        }
    }
}