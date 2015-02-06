namespace BMRF.Domain.Login
{
    public interface IForumRequestData
    {
        string SessionHash { get; set; }
        int UserID { get; set; }
        string Password { get; set; }
        string IPAddress { get; set; }
    }

    public class DefaultForumRequest : IForumRequestData
    {
        public string SessionHash { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public string IPAddress { get; set; }
    }
}
