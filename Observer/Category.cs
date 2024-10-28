using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    using System.Collections.Generic;

    public class Category
    {
        public string CategoryName { get; set; } = string.Empty;
        public List<Ad> Ads { get; private set; } = new List<Ad>();
        private List<User> subscribers = new List<User>();

        public void Subscribe(User user)
        {
            if (!subscribers.Contains(user))
            {
                subscribers.Add(user);
            }
        }

        public void AddAd(Ad ad)
        {
            Ads.Add(ad);
            NotifySubscribers(ad);
        }

        private void NotifySubscribers(Ad ad)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Update(ad);
            }
        }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
