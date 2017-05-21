using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace smart_car
{
    class Time
    {
        public async Task wait(int ms)
        {
            await Task.Delay(ms);
        }
    }
}
