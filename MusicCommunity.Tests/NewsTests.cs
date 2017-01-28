using MusicCommunityApp.Models;
using Xunit;
using System;

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

        [Fact]
        public void CanGetDate() 
        {
            //Arrange
            var date = DateTime.Now;
            var n = new News {Title = "Test", Date = date};

            //Act

            //Assert
            Assert.Equal(n.Date, date);
        }

        [Fact]
        public void CanGetStory()
        {
            //Arrange
            var story = "This is my story";
            var n = new News { Title = "Test", Date = DateTime.Now, Story = story };
            //Act

            //Assert
            Assert.Equal(n.Story, story);
        }

        [Fact]
        public void CanChangeStory()
        {
            //Arrange
            var story = "This is my story";
            var newStory = "This is a changed story";
            var n = new News { Title = "Test", Date = DateTime.Now, Story = story };

            //Act
            n.Story = newStory;

            //Assert
            Assert.Equal(n.Story, newStory);
        }
    }
}
