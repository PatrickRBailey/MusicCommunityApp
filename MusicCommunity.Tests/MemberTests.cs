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
        MemberController controller = new MemberController(repository);
        
        //Act
        List<Member> members = controller.AllMembers().ViewData.Model as List<Member>;
        
        //Assert
        Assert.Equal(repository.GetAllMembers()[0].FirstName, members[0].FirstName);
        Assert.Equal(repository.GetAllMembers()[0].LastName, members[0].LastName);
        Assert.Equal(repository.GetAllMembers()[1].FirstName, members[1].FirstName);
        Assert.Equal(repository.GetAllMembers()[1].LastName, members[1].LastName);
        }
        [Fact]
        public void CreateMember()
        {
            //Arrange
            FakeMemberRepository repo = new FakeMemberRepository();
            MemberController controller = new MemberController(repo);

            //Act
            Member member = controller.CreateNewMember().ViewData.Model as Member;
            Member newMember = repo.CreateNewMember("Luke" ,"Skywalker" ,"Skywalkersound@gmail.com");

            //Assert
            Assert.Equal(newMember.FirstName, member.FirstName);
        }
    }
}