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
        private Member user1 = new Member(){FirstName = "Gob",LastName = "Bluth",Email = "gbluth@blahblah.org"};
        private Member user2 = new Member() { FirstName = "Patrick", LastName = "Bailey",Email = "patrickb@blahblah.org" };
        public IEnumerable<Message> GetAllMessages()
        {
            var messages = new List<Message>();
            messages.Add(new Message() {Subject = "Hey", Body = "How are you doing today?", From = user1, Date= DateTime.Now, Event="Check this out"});
            messages.Add(new Message() {Subject = "Test", Body = "Yo Yo Yo", From = user1, Date= new DateTime(2017,1,23,5,30,00),Event="A new Event"});
            messages.Add(new Message() {Subject = "Foo", Body = "What's Happening?", From = user2, Date= new DateTime(2017,2,23,2,20,00),Event="A second Event"});
            messages.Add(new Message() {Subject = "Bar", Body = "Oh Hey!!", From = user2,Date= new DateTime(2017,5,13,5,30,00),Event="Another Event"});
            messages.Add(new Message() {Subject = "Hey Again", Body = "This is just a test", From= user1, Date= new DateTime(2017,3,5,12,30,00),Event="A final Event"});
            return messages;
        }

        public IEnumerable<Message> GetMessagesForMember(Member member)
        {
            var messages = new List<Message>();
            messages.Add(new Message() {Subject = "Hey", Body = "How are you doing today?", From = user1, Date= DateTime.Now, Event="Check this out"});
            messages.Add(new Message() {Subject = "Test", Body = "Yo Yo Yo", From = user1, Date= new DateTime(2017,1,23,5,30,00),Event="A new Event"});
            messages.Add(new Message() {Subject = "Foo", Body = "What's Happening?", From = user2, Date= new DateTime(2017,2,23,2,20,00),Event="A second Event"});
            messages.Add(new Message() {Subject = "Bar", Body = "Oh Hey!!", From = user2,Date= new DateTime(2017,5,13,5,30,00),Event="Another Event"});
            messages.Add(new Message() {Subject = "Hey Again", Body = "This is just a test", From= user1, Date= new DateTime(2017,3,5,12,30,00),Event="A final Event"});

            var filteredMessages = new List<Message>();
            foreach (Message m in messages)
            {
              if (m.From.Email == member.Email)
              {
                filteredMessages.Add(m);
              }
            }
            return filteredMessages;
        }
    }
}
