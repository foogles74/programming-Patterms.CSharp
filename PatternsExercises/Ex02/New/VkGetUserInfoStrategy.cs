using Patterns.Ex02.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex02
{
    internal class VkGetUserInfoStrategy : IGetUserInfoStrategy
    {
        private string GetName(string userId)
        {
            return "NAME";
        }

        private VkUser[] GetFriendsById(string userId)
        {
            return new VkUser[0];
        }

        private string Parse(string pageUrl)
        {
            return "USER_ID";
        }

        private UserInfo[] ConvertToUserInfo(VkUser[] friends)
        {
            return new UserInfo[0]; 
        }

        public UserInfo GetUserInfo(string pageUrl)
        {
            var userId = Parse(pageUrl);
            UserInfo result = new UserInfo
            {
                Name = GetName(userId),
                UserId = userId
            };

            VkUser[] users = GetFriendsById(result.UserId);
            UserInfo[] friends = ConvertToUserInfo(users);
            result.Friends = friends;
            return result;
        }
    }
}
