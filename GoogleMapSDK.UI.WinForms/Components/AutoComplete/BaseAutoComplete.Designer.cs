using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WinForms.Components.AutoComplete
{
    public partial class BaseAutoComplete<T>
    {
        private void PositionAndShowListBox()
        {
            Control host = FindForm();
            if (host == null) return; // 尚未掛到任何 Form 上，先不顯示

            if (ListBox.Parent != host)
            {
                host.Controls.Add(ListBox);
            }

            // 用「螢幕座標」轉「host 的用戶端座標」來定位，
            // 這樣不管 AutoCompleteTextBox 巢狀在幾層容器裡面，位置都會是正確的「輸入框正下方」。
            Point screenLocation = PointToScreen(new Point(0, Height + 2));
            Point hostLocation = host.PointToClient(screenLocation);

            ListBox.Left = hostLocation.X;
            ListBox.Top = hostLocation.Y;
            ListBox.Width = Math.Max(Width, 220);

            // 圓角外觀（用 Region 裁切）
            ListBox.Region = CreateRoundRegion(ListBox.Width, ListBox.Height, 6);

            ListBox.Visible = true;
            ListBox.BringToFront();
        }
        private static Region CreateRoundRegion(int width, int height, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(width - d, 0, d, d, 270, 90);
            path.AddArc(width - d, height - d, d, d, 0, 90);
            path.AddArc(0, height - d, d, d, 90, 90);
            path.CloseFigure();
            return new Region(path);
        }
        private void ResetListBox()
        {
            ListBox.Visible = false;
        }
    }
}
