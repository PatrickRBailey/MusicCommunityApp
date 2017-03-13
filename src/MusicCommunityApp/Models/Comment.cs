using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicCommunityApp.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required(ErrorMessage = "You can't submit a blank comment")]
        public string Body { get; set; }

    }
}
