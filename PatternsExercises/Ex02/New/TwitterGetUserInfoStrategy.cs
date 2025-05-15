using Patterns.Ex01.ExternalLibs.Twitter;
using Patterns.Ex02.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Patterns.Ex02
{
    internal class TwitterGetUserInfoStrategy : IGetUserInfoStrategy
    {
        readonly TwitterClient _client = new TwitterClient();

        private long GetUserId(String userName)
        {
            return _client.GetUserIdByName(userName);
        }

        public UserInfo GetUserInfo(string pageUrl)
        {
            var regex = new Regex("twitter.com/(.*)");
            var match = regex.Match(pageUrl);
            var userName = match.Success && match.Groups.Count > 1 ? match.Groups[1].Value : null;

            long userId = 0;
            if (!string.IsNullOrEmpty(userName))
            {
                userId = GetUserId(userName);
            }

            TwitterUser[] subscribers = _client.GetSubscribers(userId);

            UserInfo[] friends = subscribers
                .Select(c =>
                {
                    UserInfo userInfo = new UserInfo
                    {
                        UserId = c.UserId.ToString(),
                        Name = _client.GetUserNameById(c.UserId)
                    };
                    return userInfo;
                })
                .ToArray();

            var result = new UserInfo
            {
                Name = userName,
                UserId = userId.ToString(),
                Friends = friends
            };
            return result;
        }
    }
}
