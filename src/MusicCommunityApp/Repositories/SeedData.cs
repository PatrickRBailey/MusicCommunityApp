using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MusicCommunityApp.Models;
using Microsoft.AspNetCore.Identity;

namespace MusicCommunityApp.Repositories{
    public static class SeedData
    { 
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            string firstName = "John";
            string lastName = "Snow";
            string username = firstName + lastName;
            string email = "jsnow@thewall.org";
            string password = "king";

            UserManager<Musician> userManager = app.ApplicationServices.GetRequiredService<UserManager<Musician>>();
               
            if (!context.Messages.Any())
            {
                Musician user = await userManager.FindByNameAsync(username);
                if (user == null)
                {
                    user = new Musician { FirstName = firstName, LastName = lastName, UserName = username, Email = email };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                }

                Member member = new Member {FirstName="Johnny", LastName="Rocket"};
                context.Members.Add(member);
                Message message = new Message {Subject = "Greetings", Body="Hello and welcome to this group",EventName = "Test Event"};
                message.From = user;
                message.Comments.Add(new Comment { Body = "hello there" });
                context.Messages.Add(message);
                message = new Message {Subject = "Introduction", Body="Hello, my name is Johnny and I'm looking for a place to jam", From = user, EventName = "Another Event" };
                context.Messages.Add(message);
           
                member = new Member {FirstName="Bob", LastName="Loblaw"};
                context.Members.Add(member);
                message = new Message {Subject = "Greetings", Body="Thank you for the invite", From = user, EventName = "Test Event" };
                message.Comments.Add(new Comment { Body = "how are you" });
                context.Messages.Add(message);
                message = new Message {Subject = "Introduction", Body="Hello Johnny, I've got a place to jam!!", From = user, EventName = "Test Event" };
                context.Messages.Add(message);

                context.SaveChanges();
                
            }
        }
    }
}