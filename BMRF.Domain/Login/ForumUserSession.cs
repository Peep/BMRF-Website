using System;
using System.Linq;
using BMRF.Domain.DataModels;
using BMRF.Domain.Entities;

namespace BMRF.Domain.Login
{
    public class ForumUserSession
    {
        private readonly string _bbSessionHash;
        private readonly int _bbUserID;
        private readonly string _bbPassword;

        private readonly string _ipAddress;
        private int _lastActive;

        private int? _forumId;
        private int _usergroupid;
        private int[] _membergroupids;
        private string _username;
        private string _email;
        private string _usertitle;

        public ForumUserSession(IForumRequestData request)
        {
            if (request.IPAddress != null)
                _ipAddress = request.IPAddress;

            if (request.SessionHash != null)
                _bbSessionHash = request.SessionHash;

            if (request.UserID != 0)
                _bbUserID = request.UserID;

            if (request.Password != null)
                _bbPassword = request.Password;
        }

        public ForumUser BuildUser()
        {
            if (_bbSessionHash == null) return null;

            GetSession();

            if (_forumId == null && _bbUserID != 0 && _bbPassword != null)
                GetCookies();

            if (_forumId == null || _forumId == 0) return null;
            GetUserDetails(); // populate the rest of the fields
            UpdateActivity(); // update activity variables
            return new ForumUser
            {
                UserId = Convert.ToInt32(_forumId),
                Email = _email,
                MemberGroupIds = _membergroupids,
                Name = _username,
                UserGroupId = _usergroupid,
                UserTitle = _usertitle
            };
        }

        private void GetSession()
        {
            VBulletinSession session;
            using (var sessionDb = new VBulletinSessionDataModel())
                session = (from user in sessionDb.Sessions
                           where user.sessionhash == _bbSessionHash
                           select user).FirstOrDefault();

            if (session == null) return;

            int? userId = Convert.ToInt32(session.userid);
            _lastActive = Convert.ToInt32(session.lastactivity);
            _forumId = ((Util.UnixTime() - _lastActive) < 900 ? userId : null);
        }

        private void GetCookies()
        {
            const string cookieSalt = "3MKiSbAbgNBzhcdoYy4pxOPwhE";
            int userID;
            string dbPass;

            using (var context = new VBulletinUserDataModel())
            {
                userID = (from u in context.Users
                    where u.userid == _bbUserID
                    select u.userid).FirstOrDefault();

                if (userID == 0) return;

                dbPass = (from u in context.Users
                    where u.userid == _bbUserID
                    select u.password).FirstOrDefault();
            }

            string hash = Util.CalculateMD5Hash(dbPass + cookieSalt).ToLower();

            if (hash == _bbPassword)
            {
                _forumId = userID;
                return;
            }

            _forumId = null;
        }

        private void GetUserDetails()
        {
            VBulletinUser user;
            using (var userDb = new VBulletinUserDataModel())
                user = (from u in userDb.Users
                        where u.userid == _forumId
                        select u).First();

            _usergroupid = Convert.ToInt32(user.usergroupid);
            
            _username = user.username;
            _email = user.email;
            _usertitle = user.usertitle;

            var groups = user.membergroupids;
            if (!String.IsNullOrWhiteSpace(groups))
            {
                var strings = groups.Split(new[] {','});
                _membergroupids = strings.Select(int.Parse).ToArray();
            }
        }

        private void UpdateActivity()
        {
            using (var userDb = new VBulletinUserDataModel())
            {
                var user = (from u in userDb.Users
                            where u.userid == _forumId
                            select u).First();

                user.lastactivity = _lastActive;
                user.ipaddress = _ipAddress;

                if (Util.UnixTime() - _lastActive > 900)
                    user.lastvisit = _lastActive;

                userDb.SaveChanges();
            }
        }
    }
}
