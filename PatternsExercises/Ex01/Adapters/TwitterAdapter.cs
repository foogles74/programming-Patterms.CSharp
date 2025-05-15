using Patterns.Ex01.Abstract;
using Patterns.Ex01.ExternalLibs.Instagram;
using Patterns.Ex01.ExternalLibs.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex01.Adapters
{
    public class TwitterAdapter : ISocialNetworkSubscriberFetcher
    {
        private readonly TwitterClient twitterClient = new TwitterClient();

        public SocialNetworkUser[] GetSubscribers(string userName)
        {
            long userId = twitterClient.GetUserIdByName(userName);
            TwitterUser[] twitterUsers = twitterClient.GetSubscribers(userId);
            return twitterUsers.Select(user => new SocialNetworkUser { UserName = twitterClient.GetUserNameById(user.UserId) }).ToArray();
        }
    }
}
