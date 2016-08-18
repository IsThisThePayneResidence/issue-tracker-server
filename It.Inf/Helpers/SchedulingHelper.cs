using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace It.Inf.Helpers
{
    public static class SchedulingHelper
    {
        public static void Schedule(Func<bool> task, long milliseconds)
        {
            var timer = new Timer(milliseconds);
            timer.Elapsed += (sender, args) => task();
        }
    }
}
