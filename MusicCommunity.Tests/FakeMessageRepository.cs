using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCommunityApp.Models;
using MusicCommunityApp.Repositories;


namespace MusicCommunity.Tests
{
    public class FakeMessageRepository : IMessage
    {
        public List<Message> GetAllMessages()
        {
            var messages = new List<Message>();
            messages.Add(new Message() {Subject = "Hey", Body = "How are you doing today?"});
            messages.Add(new Message() {Subject = "Hey Again", Body = "This is just a test"});
            return messages;
        }

        public List<Message> GetMessagesForMember(Member member)
        {
            var user = new Member(){FirstName="Luke", LastName="Skywalker", Email="usetheforce@gmail.com"};
            var messages = new List<Message>();
            messages.Add(new Message() {Subject = "Hey", Body = "How are you doing today?", From = user});
            messages.Add(new Message() {Subject = "Hey Again", Body = "This is just a test"});

            var filteredMessages = new List<Message>();
            foreach (var m in messages)
            {
              if (m.From == member)
              {
                filteredMessages.Add(m);
              }
            }
            return filteredMessages;
        }
    }
}
