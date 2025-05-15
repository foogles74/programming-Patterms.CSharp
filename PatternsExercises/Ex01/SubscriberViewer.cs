using Patterns.Ex01.Abstract;
using Patterns.Ex01.Adapters;
using System;

namespace Patterns.Ex01
{
    public class SubscriberViewer
    {
        /// <summary>
        /// ������� ��������� ISocialNetworkSubscriberFetcher
        /// �������� InstagramAdapter TwitterAdapter ������� ����������� �� ISocialNetworkSubscriberFetcher
        /// <returns></returns>
        public SocialNetworkUser[] GetSubscribers(String userName, SocialNetwork networkType)
        {
            ISocialNetworkSubscriberFetcher fetcher;

            switch (networkType)
            {
                case SocialNetwork.Instagram:
                    fetcher = new InstagramAdapter();
                    break;
                case SocialNetwork.Twitter:
                    fetcher = new TwitterAdapter();
                    break;
                default:
                    return null;
            }

            return fetcher.GetSubscribers(userName);
        }
    }
}