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
        HomeController controller = new HomeController(repository);
        
        //Act
        List<Member> members = controller.Members().ViewData.Model as List<Member>;
        
        //Assert
        Assert.Equal(repository.GetAllMembers()[0].FirstName, members[0].FirstName);
        Assert.Equal(repository.GetAllMembers()[0].LastName, members[0].LastName);
        Assert.Equal(repository.GetAllMembers()[1].FirstName, members[1].FirstName);
        Assert.Equal(repository.GetAllMembers()[1].LastName, members[1].LastName);
        }

    }
}