using LibUsbDotNet.DeviceNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace USBMonitorService
{
    static class Program
    {
        public static IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //设备的监听事件
            UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;

            //键盘有任意键按下将结束
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Waiting for system level device events..");
            Console.Write("[Press any key to exit]");

            while (!Console.KeyAvailable)
            {
                // Application.DoEvents();
            }

            UsbDeviceNotifier.Enabled = false;

            UsbDeviceNotifier.OnDeviceNotify -= OnDeviceNotifyEvent;

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MonitorService()
            };
            ServiceBase.Run(ServicesToRun);
        }
        private static void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            //事件发生
            //设置光标的位置
            Console.SetCursorPosition(0, Console.CursorTop);

            Console.WriteLine(e.ToString());//将事件输出

            Console.WriteLine();
            Console.Write("[Press any key to exit]");
        }

    }
}
