using System;
using System.Collections.Generic;
using BMRF.Domain.DataStructures;

namespace BMRF.Domain.Entities
{
    public class AdminIndexData
    {
        public IEnumerable<ForumPost> GetLatestPosts()
        {
            throw new NotImplementedException();
            // TODO: implement
            //using (var postDb = new VBulletinPostsDataModel())
            //{
            //    var k = (from p in postDb.Posts
            //             where p.parentid == 0
            //             select new ForumPost
            //             {
            //                 Title = p.title,
            //                 Description = p.pagetext
            //             })
            //}
        }
    }
}
