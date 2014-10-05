using System;

namespace BMRF.Domain.DataStructures
{
    public class ForumPost
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
