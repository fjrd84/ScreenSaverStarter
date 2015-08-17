using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; 

namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
       
        public Form1()
        {
            InitializeComponent();
        }

        public const uint WM_SYSCOMMAND = 0x112;
        public const uint SC_SCREENSAVE = 0xF140;
        public const uint SC_MONITORPOWER = 0xF170;
        public enum SpecialHandles
        {
            HWND_DESKTOP = 0x0,
            HWND_BROADCAST = 0xFFFF
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sendSysCommand(SC_SCREENSAVE, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.sendSysCommand(SC_MONITORPOWER, 2);
        }

        private void sendSysCommand(uint message, int lparam) {
            Message msg = new Message();
            msg.Msg = (int)WM_SYSCOMMAND;
            SendMessage(this.Handle, msg.Msg, (int)message, lparam);
        }
    }
}
