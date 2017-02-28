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
        public string Body { get; set; }

    }
}
