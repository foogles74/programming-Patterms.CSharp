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
    public class InstagramAdapter : ISocialNetworkSubscriberFetcher
    {
        private readonly InstagramClient instagramClient = new InstagramClient();

        public SocialNetworkUser[] GetSubscribers(string userName)
        {
            InstagramUser[] instagramUsers = instagramClient.GetSubscribers(userName);
            return instagramUsers.Select(user => new SocialNetworkUser { UserName = user.UserName }).ToArray();
        }
        
    }
}
