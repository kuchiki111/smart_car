using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace smart_car
{
    class PWM
    {
        public GpioPin channel;
        public double frequency;

        public PWM(GpioPin channel, double frequency)
        {
            this.channel = channel;
            this.frequency = frequency;
        }

        public void start(double dc)
        {

        }

        public void ChangeFrequency(double frequency)
        {

        }

        public void ChangeDutyCycle(double dc)
        {

        }

        public void stop()
        {

        }


    }
}
