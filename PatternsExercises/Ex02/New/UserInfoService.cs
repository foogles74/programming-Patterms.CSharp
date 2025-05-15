using Patterns.Ex01;
using Patterns.Ex02.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex02.New
{
    internal class UserInfoService
{
        private readonly IGetUserInfoStrategy _strategy;

        public UserInfoService(IGetUserInfoStrategy strategy)
        {
            _strategy = strategy;
        }

        public UserInfoService(SocialNetwork networkType)
        {
            _strategy = GetStrategyForNetwork(networkType);
        }

        private IGetUserInfoStrategy GetStrategyForNetwork(SocialNetwork networkType)
        {
            switch (networkType)
            {
                case SocialNetwork.Instagram:
                    return null;
                case SocialNetwork.Twitter:
                    return new TwitterGetUserInfoStrategy();
                case SocialNetwork.VK:
                    return new VkGetUserInfoStrategy();
                default:
                    return null;
            }
        }
        public UserInfo GetUserInfo(string pageUrl)
        {
            return _strategy.GetUserInfo(pageUrl);
        }
    }
}
