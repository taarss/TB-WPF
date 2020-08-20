using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;
using WPF_gaming_3.CharCreation;

namespace WPF_gaming_3.backend
{
    class tick
    {
        static DispatcherTimer ticker = new DispatcherTimer();
        public static void start_tick()
        {
            ticker.Interval = new TimeSpan(1000);
            //ticker.Tick += Timer_Tick;
            ticker.Start();

        }
    }
}
