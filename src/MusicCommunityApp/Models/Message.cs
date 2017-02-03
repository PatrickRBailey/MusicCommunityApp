﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCommunityApp.Models
{
    public class Message
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member From { get; set; }
        public string Event { get; set; }
    }
}
