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

        /*public static extern int SendMessage
            (IntPtr hWnd,
            uint Msg,
            uint wParam,
            uint lParam);*/
        public const uint WM_SYSCOMMAND = 0x112;
        public const uint SC_SCREENSAVE = 0xF140;
        public enum SpecialHandles
        {
            HWND_DESKTOP = 0x0,
            HWND_BROADCAST = 0xFFFF
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // With this code, the screensaver can be triggered. Useful for testing
            //PostMessage(hwnd, /*WM_SYSCOMMAND*/0x0112, /*SC_SCREENSAVE*/0xF140, 5);
            // This message triggers the screensaver
            //new IntPtr((int)SpecialHandles.HWND_BROADCAST)
            Message msg = new Message();
            msg.Msg = (int)WM_SYSCOMMAND;
            SendMessage(this.Handle, msg.Msg, (int)SC_SCREENSAVE, 0);
            //System.Threading.Thread.Sleep(1000);
        }
    }
}
