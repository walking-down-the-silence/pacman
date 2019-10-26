using System;
using Xunit;

namespace PacMan.Tests
{
    public class OffsetTests
    {
        [Fact]
        public void Shift_WithOffset2X0Y_After2Seconds_ShouldBe4X0Y()
        {
            // Arrange
            const int elapsedSeconds = 2;
            DateTime last = new DateTime(2018, 07, 01, 12, 0, 15);
            DateTime now = last.AddSeconds(elapsedSeconds);
            Offset shiftPerSecond = new Offset(2, 0);
            Offset expected = new Offset(4, 0);

            // Act
            var shiftOverTime = shiftPerSecond.Extend(last, now);

            // Assert
            Assert.Equal(expected.Left, shiftOverTime.Left);
            Assert.Equal(expected.Top, shiftOverTime.Top);
        }

        [Fact]
        public void Shift_WithOffset6X0y_AfterHalfASecond_ShouldBe3X0Y()
        {
            // Arrange
            const double elapsedSeconds = 0.5;
            DateTime last = new DateTime(2018, 07, 01, 12, 0, 15);
            DateTime now = last.AddSeconds(elapsedSeconds);
            Offset shiftPerSecond = new Offset(6, 0);
            Offset expected = new Offset(3, 0);

            // Act
            var shiftOverTime = shiftPerSecond.Extend(last, now);

            // Assert
            Assert.Equal(expected.Left, shiftOverTime.Left);
            Assert.Equal(expected.Top, shiftOverTime.Top);
        }
    }
}
