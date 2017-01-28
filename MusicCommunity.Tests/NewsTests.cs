using MusicCommunityApp.Models;
using Xunit;

namespace MusicCommunity.Tests
{
    public class NewsTests
    {
      [Fact]
      public void CanChangeTitle()
        {
            //Arrange
            var title = "New Title";
            var n = new News { Title = "Test" };
            // Act
            n.Title = title;
            // Assert
            Assert.Equal(title, n.Title);
        }
    }
}
