using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;

namespace smart_car
{
    class PWM
    {
        public GpioPin channel;
        public double frequency;
        public double dc;
        public Boolean run = true;

        public PWM(GpioPin channel, double frequency)
        {
            this.channel = channel;
            this.frequency = frequency;
        }

        public void start(double dc)
        {
            this.dc = dc;
            run = true;
            Windows.System.Threading.ThreadPool.RunAsync(PWMthread, Windows.System.Threading.WorkItemPriority.High);
        }

        private void PWMthread(IAsyncAction operation)
        {
            int hightime = Convert.ToInt32((1000 / frequency) * (dc / 100));
            int lowtime = Convert.ToInt32((1000 / frequency) - hightime);

            while (run)
            {
                channel.Write(GpioPinValue.High);
                Task.Delay(hightime);
                channel.Write(GpioPinValue.Low);
                Task.Delay(lowtime);

            }
        }

        public void ChangeFrequency(double frequency)
        {
            this.frequency = frequency;
            start(dc);
        }

        public void ChangeDutyCycle(double dc)
        {
            this.dc = dc;
            start(dc);
        }

        public void stop()
        {
            run = false;
        }


    }
}
