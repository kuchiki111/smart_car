using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;
using System.Threading.Tasks;
using System.Threading;

namespace smart_car
{

    public sealed partial class MainPage : Page
    {
        myGpioPin mypin = new myGpioPin();
        private DispatcherTimer timer;
        public MainPage()
        {
            GpioController gpio = GpioController.GetDefault();
            InitializeComponent();
            //mypin.pin4 = gpio.OpenPin(4);
            //mypin.pin4.SetDriveMode(GpioPinDriveMode.Output);

            //PWM p = new PWM(mypin.pin4, 1000);
            //p.start(50);
            init();
            forword(10000);
        }


        public void init()
        {
            GpioController gpio = GpioController.GetDefault();
            
            mypin.pin5 = gpio.OpenPin(5);
            mypin.pin6 = gpio.OpenPin(6);
            mypin.pin23 = gpio.OpenPin(23);
            mypin.pin24 = gpio.OpenPin(24);
            mypin.pin17 = gpio.OpenPin(17);
            mypin.pin27 = gpio.OpenPin(27);

            mypin.pin5.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin6.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin23.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin24.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin17.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin27.SetDriveMode(GpioPinDriveMode.Output);

        }

        public void forword(int time)
        {
            mypin.pin5.Write(GpioPinValue.High);
            mypin.pin6.Write(GpioPinValue.Low);
            mypin.pin23.Write(GpioPinValue.High);
            mypin.pin24.Write(GpioPinValue.Low);

            PWM p1 = new PWM(mypin.pin17, 15000);
            PWM p2 = new PWM(mypin.pin27, 15000);

            p1.start(98);
            p2.start(98);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(time);
            timer.Start();

        }

    }

}
