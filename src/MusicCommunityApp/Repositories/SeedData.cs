using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!context.Messages.Any())
            {
                Member member = new Member {FirstName="Johnny", LastName="Rocket"};
                context.Members.Add(member);
                Message message = new Message {Subject = "Greetings", Body="Hello and welcome to this group"};
                message.From = member;
                context.Messages.Add(message);
                message = new Message {Subject = "Introduction", Body="Hello, my name is Johnny and I'm looking for a place to jam", From = member};
                context.Messages.Add(message);

                member = new Member {FirstName="Bob", LastName="Loblaw"};
                context.Members.Add(member);
                message = new Message {Subject = "Greetings", Body="Thank you for the invite", From = member};
                context.Messages.Add(message);
                message = new Message {Subject = "Introduction", Body="Hello Johnny, I've got a place to jam!!", From = member};
                context.Messages.Add(message);

                context.SaveChanges();
                
            }
        }
    }
}