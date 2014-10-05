using BMRF.Domain.Abstract;

namespace BMRF.Domain.Login
{
    public class DefaultForumRequest : IForumRequestData
    {
        public string SessionHash { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public string IPAddress { get; set; }
    }
}
