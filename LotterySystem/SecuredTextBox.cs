using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotterySystem
{
    public class SecuredTextBox : TextBox
    {
        const int WM_PASTE = 0x302;
        const int WM_CONTEXTMENU = 0x7B;

        [SecurityPermission(SecurityAction.Demand,
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                return;
            }

            if (m.Msg == WM_CONTEXTMENU)
            {
                return;
            }

            base.WndProc(ref m);
        }
    }
}
