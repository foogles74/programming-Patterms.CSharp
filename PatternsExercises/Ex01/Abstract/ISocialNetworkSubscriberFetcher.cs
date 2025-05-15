using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex01.Abstract
{
    public interface ISocialNetworkSubscriberFetcher
    {
        SocialNetworkUser[] GetSubscribers(string userName);
    }
}
