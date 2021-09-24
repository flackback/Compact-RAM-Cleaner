using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compact_RAM_Cleaner
{
    public partial class Notify : Shadows
    {
        public Notify()
        {
            InitializeComponent();
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 10, Screen.PrimaryScreen.WorkingArea.Height - Height - 10);
            NotifyText.Text = Popup.NotifyText;
        }

        async void Notify_Load(object sender, EventArgs e)
        {
            for (Opacity = 0; Opacity < 1; Opacity += 0.1)
                await Task.Delay(10);
            await Task.Delay(4000);
            Close();
        }

        void Notify_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(48, 49, 54), 2);
            e.Graphics.DrawLine(pen, 0, Height, Width, Height);
        }
    }
}
