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

        public MainPage()
        {
            this.InitializeComponent();

        }


        public void init()
        {
            GpioController gpio = GpioController.GetDefault();

            mypin.pin5 = gpio.OpenPin(7);
            mypin.pin6 = gpio.OpenPin(11);
            mypin.pin23 = gpio.OpenPin(13);
            mypin.pin24 = gpio.OpenPin(15);
            mypin.pin17 = gpio.OpenPin(16);
            mypin.pin27 = gpio.OpenPin(18);

            mypin.pin5.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin6.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin23.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin24.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin17.SetDriveMode(GpioPinDriveMode.Output);
            mypin.pin27.SetDriveMode(GpioPinDriveMode.Output);

        }

        public void forword(int time)
        {
            init();

            mypin.pin5.Write(GpioPinValue.High);
            mypin.pin6.Write(GpioPinValue.Low);
            mypin.pin5.Write(GpioPinValue.High);
            mypin.pin6.Write(GpioPinValue.Low);

            Task.Delay(time);

        }

    }

}
