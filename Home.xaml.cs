using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdBlock
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private static Timer aTimer;
        private static MemoryMappedFile mmf;
        private static MemoryMappedViewAccessor accessor;

        public Home()
        {
            InitializeComponent();
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            mmf = MemoryMappedFile.OpenExisting("AdBlockStats");
            accessor = mmf.CreateViewAccessor(0, 1024);
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs args)
        {
            this.Dispatcher.Invoke(() =>
            {
                Info info;
                accessor.Read(0, out info);
                PacketsLabel.Content = info.Packets;
                BlockedLabel.Content = info.Blocked;
                HTTPLabel.Content = info.HTTP;

            });
        }
    }

    public struct Info {
        public UInt16 Packets;
        public UInt16 Blocked;
        public UInt16 HTTP;
        public UInt16 HTTPS;
        public UInt16 WS;
        public UInt16 WSS;
        public UInt16 Errors;
    }
}
