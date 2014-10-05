using BMRF.Domain.Login;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMRF.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForumLogin()
        {
            // arrange
            int userId = 1;
            string sessionHash = "b3ef6b3d2553fb50ef698a19567245f8";
            string password = "b516ade5184a1a62eaeb07a80045362a";

            var forumRequest = new DefaultForumRequest()
            {
                IPAddress = "192.168.1.1",
                SessionHash = sessionHash,
                UserID = userId,
                Password = password
            };

            // act
            var forumSession = new ForumUserSession(forumRequest);
            var forumUser = forumSession.BuildUser();

            // asset
            Assert.IsNotNull(forumUser);
        }
    }
}
