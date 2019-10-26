using Xunit;

namespace PacMan.Tests
{
    public class CircularListTests
    {
        [Fact]
        public void GetEnumerator_OnEmptyList_ShouldReturnEmptyEnumerator()
        {
            // Arrange
            var circularList = new CircularList<int>();

            // Act
            var enumerator = circularList.GetEnumerator();

            // Assert
            Assert.NotNull(enumerator);
            Assert.Equal(default(int), enumerator.Current);
        }

        [Fact]
        public void GetEnumerator_OnFullList_ShouldReturnValidEnumerator()
        {
            // Arrange
            var circularList = new CircularList<int>(new[] { 1, 2, 3 });

            // Act, Assert
            Assert.NotNull(circularList.GetEnumerator());
            Assert.Equal(2, circularList.Next());
            Assert.Equal(3, circularList.Next());
            Assert.Equal(1, circularList.Next());
            Assert.Equal(2, circularList.Next());
            Assert.Equal(3, circularList.Next());
        }

        [Fact]
        public void GetEnumerator_OnFullList_CurrentShouldBeEqualTo1()
        {
            // Arrange
            var circularList = new CircularList<int>(new[] { 1, 2, 3 });

            // Act, Assert
            Assert.Equal(1, circularList.Current);
        }
    }
}
