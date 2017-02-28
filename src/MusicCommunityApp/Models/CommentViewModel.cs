using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCommunityApp.Models
{
    public class CommentViewModel
    {
        public int MessageID { get; set; }
        public Comment Comment { get; set; }
    }
}
