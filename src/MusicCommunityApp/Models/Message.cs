using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCommunityApp.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required(ErrorMessage = "A Message Must have a Subject")]
        [StringLength(50, MinimumLength = 3)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please Enter Text in the Body")]
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member From { get; set; }

        [Required(ErrorMessage = "An Event can't have numbers")]
        [RegularExpression("^[a-z A-Z /s]*$")]
        public string EventName { get; set; }
        private List<Comment> comments = new List<Comment>();
        public List <Comment> Comments { get { return comments; } }
    }
}
