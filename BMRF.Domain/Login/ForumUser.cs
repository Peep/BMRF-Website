namespace BMRF.Domain.Login
{
    public class ForumUser
    {
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public int[] MemberGroupIds { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserTitle { get; set; }

        public string ErrorText { get; set; }
    }
}
