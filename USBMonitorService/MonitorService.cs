using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace USBMonitorService
{
    public partial class MonitorService : ServiceBase
    {
        public MonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //C#接收所有窗口消息
            //HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;//窗口过程

        }

        protected override void OnStop()
        {
        }
    }
}
