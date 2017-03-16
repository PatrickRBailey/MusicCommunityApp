using System.Collections.Generic;
using MusicCommunityApp.Models;
using MusicCommunityApp.Controllers;
using System.Linq;
using Xunit;

namespace MusicCommunity.Tests
{
    public class MessageTests
    {
        List<Message> repoList;
        [Fact]
        public void GetAllMessages()
        {
            //Arrange
            FakeMessageRepository repo = new FakeMessageRepository();
            //ForumController controller = new ForumController(repo);

            //Act 
            //List<Message> messages = controller.AllMessages().ViewData.Model as List<Message>;
            repoList = repo.GetAllMessages().ToList();

            //Assert
           // Assert.Equal(repoList[0].Subject, messages[0].Subject);
           // Assert.Equal(repoList[0].Body, messages[0].Body);
            //Assert.Equal(repoList[1].Subject, messages[1].Subject);
            //Assert.Equal(repoList[1].Body, messages[1].Body);
        }

        [Fact]
        public void GetMessagesByMember()
        {
            //Arrange
            FakeMessageRepository messageRepo = new FakeMessageRepository();
            //ForumController controller = new ForumController(messageRepo);
            

            FakeMemberRepository memberRepo = new FakeMemberRepository();
            HomeController controller2 = new HomeController(memberRepo);
            

            //Act
            List<Member> members = controller2.Members().ViewData.Model as List<Member>;
            Member user = members[0];
           // List<Message> messages = controller.MyMessages(user).ViewData.Model as List<Message>;
            repoList = messageRepo.GetMessagesForMember(user).ToList();
            

            //Assert
           // Assert.Equal(repoList[0].From.Email, messages[0].From.Email);
        }
    }
}