using System.Collections.Generic;
using MusicCommunityApp.Models;
using MusicCommunityApp.Controllers;
using Xunit;

namespace MusicCommunity.Tests
{
    public class MemberTests
    {
        [Fact]
        public void GetsAllMembers()
        {
        //Arrange
        FakeMemberRepository repository = new FakeMemberRepository();
        ForumController controller = new ForumController(repository);
        
        //Act
        List<Member> members = controller.AllMembers().ViewData.Model as List<Member>;
        
        //Assert
        Assert.Equal(repository.GetAllMembers()[0].FirstName, members[0].FirstName);
        Assert.Equal(repository.GetAllMembers()[0].LastName, members[0].LastName);
        Assert.Equal(repository.GetAllMembers()[1].FirstName, members[1].FirstName);
        Assert.Equal(repository.GetAllMembers()[1].LastName, members[1].LastName);
        }
        [Fact]
        public void GetMemberByMessage()
        {
            //Arrange
            FakeMemberRepository repo = new FakeMemberRepository();
            ForumController controller = new ForumController(repo);

            //Act
            Member member = controller.Member().ViewData.Model as Member;
            Member user = new Member(){FirstName="Luke", LastName="Skywalker", Email="usetheforce@gmail.com"};
            Message message = new Message() {Subject = "Hey", Body = "How are you doing today?"};
            message.From = user;

            //Assert
            Assert.Equal(repo.GetMemberByMessage(message).FirstName, member.FirstName);
        }
    }
}