namespace BMRF.Domain.Abstract
{
    public interface IForumRequestData
    {
        string SessionHash { get; set; }
        int UserID { get; set; }
        string Password { get; set; }
        string IPAddress { get; set; }
    }
}
