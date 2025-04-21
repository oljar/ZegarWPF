using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ZegarWPF.ModelWidoku
{
    public class Zegar : ObservedObject
    {

        private readonly bool isInDesignMode = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
        public DateTime AktualnyCzas
        {
            get
            {
                return DateTime.Now;
            }
        }

        private const int okresOdświerzaniaWidoku = 250; // 1 sekunda
        public Zegar()
        {
            DispatcherTimer timerOdświeżeniaWidoku = new DispatcherTimer();
            timerOdświeżeniaWidoku.Tick += (sender, e) => onPropertyChanged(nameof(AktualnyCzas));
            timerOdświeżeniaWidoku.Interval = TimeSpan.FromMilliseconds(okresOdświerzaniaWidoku);
            //timerOdświeżeniaWidoku.Start();
            if (!isInDesignMode)
            {
                timerOdświeżeniaWidoku.Start();
            }
        }

    }
}
