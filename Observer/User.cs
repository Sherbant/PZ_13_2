using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Observer
{
    public class User : IObserver
    {
        public string Name { get; set; }

        public void Update(Ad ad)
        {
            MessageBox.Show($"{Name}, новое объявление в категории {ad.Category}: {ad.Title}");
        }
    }
}
