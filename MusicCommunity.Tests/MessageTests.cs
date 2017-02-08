using System.Collections.Generic;
using MusicCommunityApp.Models;
using MusicCommunityApp.Controllers;
using Xunit;

namespace MusicCommunity.Tests
{
    public class MessageTests
    {
        [Fact]
        public void GetAllMessages()
        {
            //Arrange
            FakeMessageRepository repo = new FakeMessageRepository();
            ForumController controller = new ForumController(repo);

            //Act 
            List<Message> messages = controller.AllMessages().ViewData.Model as List<Message>;

            //Assert
            Assert.Equal(repo.GetAllMessages()[0].Subject, messages[0].Subject);
            Assert.Equal(repo.GetAllMessages()[0].Body, messages[0].Body);
            Assert.Equal(repo.GetAllMessages()[1].Subject, messages[1].Subject);
            Assert.Equal(repo.GetAllMessages()[1].Body, messages[1].Body);
        }

        [Fact]
        public void GetMessagesByMember()
        {
            //Arrange
            FakeMessageRepository messageRepo = new FakeMessageRepository();
            ForumController controller = new ForumController(messageRepo);

            FakeMemberRepository memberRepo = new FakeMemberRepository();
            MemberController controller2 = new MemberController(memberRepo);
            

            //Act
            List<Message> messages = controller.MyMessages().ViewData.Model as List<Message>;
            List<Member> members = controller2.AllMembers().ViewData.Model as List<Member>;
            Member user = members[0];

            //Assert
            Assert.Equal(messageRepo.GetMessagesForMember(user)[0].From.Email, messages[0].From.Email);
        }
    }
}