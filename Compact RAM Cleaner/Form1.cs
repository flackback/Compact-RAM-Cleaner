using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compact_RAM_Cleaner
{
    public partial class Form1 : Shadows
    {
        #region Paint
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(48, 49, 54), 2), 0, Height, Width, Height);
            Pen pen = new Pen(SystemColors.ControlDark, 2);
            e.Graphics.DrawLine(pen, 12, LabelMon.Location.Y + 10, Width - 12, LabelMon.Location.Y + 10);
            e.Graphics.DrawLine(pen, 12, LabelSettings.Location.Y + 10, Width - 12, LabelSettings.Location.Y + 10);
        }
        void ClosePanel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(160, 160, 160), 2);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(pen, 4, 4, ClosePanel.Width - 4, ClosePanel.Height - 4);
            e.Graphics.DrawLine(pen, 4, ClosePanel.Height - 4, ClosePanel.Width - 4, 4);
        }
        void Minimize_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160), 2), 4, 9, Minimize.Width - 4, 9);
        }
        #endregion

        [DllImport("user32.dll", CharSet = CharSet.Auto)] extern static bool DestroyIcon(IntPtr handle);
        [DllImport("psapi.dll")] static extern int EmptyWorkingSet([In] IntPtr obj0);
        [DllImport("advapi32.dll", SetLastError = true)] internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        [DllImport("advapi32.dll", SetLastError = true)] internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        [DllImport("ntdll.dll")] static extern UInt32 NtSetSystemInformation(int InfoClass, IntPtr Info, int Length);
        [StructLayout(LayoutKind.Sequential, Pack = 1)] struct SYSTEM_CACHE_INFORMATION
        {
            public long CurrentSize;
            public long PeakSize;
            public long PageFaultCount;
            public long MinimumWorkingSet;
            public long MaximumWorkingSet;
            public long Unused1;
            public long Unused2;
            public long Unused3;
            public long Unused4;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)] internal struct TokPriv1Luid { public int Count; public long Luid; public int Attr; }
        void ClearCache()
        {
            try
            {
                if (SetIncreasePrivilege("SeIncreaseQuotaPrivilege"))
                {
                    SYSTEM_CACHE_INFORMATION sc = new SYSTEM_CACHE_INFORMATION
                    { MinimumWorkingSet = is64Bit ? -1L : uint.MaxValue, MaximumWorkingSet = is64Bit ? -1L : uint.MaxValue };
                    int sys = Marshal.SizeOf(sc);
                    GCHandle gcHandle = GCHandle.Alloc(sc, GCHandleType.Pinned);
                    uint num = NtSetSystemInformation(0x0015, gcHandle.AddrOfPinnedObject(), sys);
                    gcHandle.Free();
                }

                if (SetIncreasePrivilege("SeProfileSingleProcessPrivilege"))
                {
                    int sys = Marshal.SizeOf(4);
                    GCHandle gcHandle = GCHandle.Alloc(4, GCHandleType.Pinned);
                    uint num = NtSetSystemInformation(0x0050, gcHandle.AddrOfPinnedObject(), sys);
                    gcHandle.Free();
                }
            }
            catch { }
        }
        bool SetIncreasePrivilege(string privilegeName)
        {
            using (WindowsIdentity current = WindowsIdentity.GetCurrent(TokenAccessLevels.Query | TokenAccessLevels.AdjustPrivileges))
            {
                TokPriv1Luid tokPriv1Luid;
                tokPriv1Luid.Count = 1;
                tokPriv1Luid.Luid = 0L;
                tokPriv1Luid.Attr = 2;
                if (!LookupPrivilegeValue(null, privilegeName, ref tokPriv1Luid.Luid)) return false;
                return AdjustTokenPrivileges(current.Token, false, ref tokPriv1Luid, 0, IntPtr.Zero, IntPtr.Zero);
            }
        }

        public Form1()
        {
            InitializeComponent();
            Resize += (s, e) => { if (WindowState == FormWindowState.Minimized) Hide(); };
            Button1.Click += (s, e) => Ram(false);
            NotifyIcon1.MouseClick += (s, e) => { if (e.Button == MouseButtons.Left) { Show(); WindowState = FormWindowState.Normal; } else if (e.Button == MouseButtons.Middle) Ram(false); };
            Menu1.Click += (s, e) => Ram(false);
            Menu2.Click += (s, e) => Exit();
            Menu3.Click += (s, e) => { Ram(false); if (!CacheCheck.Checked) ClearCache(); };
            ClosePanel.Click += (s, e) => Exit();
            Minimize.Click += (s, e) => WindowState = FormWindowState.Minimized;
            new List<Control> { TitlePanel, Label1, Label2, Label3, label4, label5, label6, LabelSettings, LabelMon, AppName }.ForEach(x =>
            {
                x.MouseDown += (s, a) => { x.Capture = false; Capture = false; Message m = Message.Create(Handle, 0xA1, new IntPtr(2), IntPtr.Zero); base.WndProc(ref m); };
            });
            checkBox1.CheckedChanged += (s, e) =>
            {
                if (checkBox1.Checked)
                {
                    AutoCleaner();
                    Numeric1.Enabled = false;
                }
                else Numeric1.Enabled = true;
            };
            checkBox3.CheckedChanged += (s, e) =>
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"))
                {
                    if (checkBox3.Checked) key.SetValue("Compact RAM Cleaner", $"\"{Path.GetDirectoryName(Application.ExecutablePath)}\\Compact RAM Cleaner.exe\" silent");
                    else try { key.DeleteValue("Compact RAM Cleaner"); } catch { };
                }
            };
            radioButton1.CheckedChanged += (s, e) => Lang();
            Tray();
            Label2.Text = $"{GetSize(TotalRam())}";
            foreach (var arg in Environment.GetCommandLineArgs()) silent = arg.EndsWith("silent");
        }

        ulong num;
        ulong ram;
        readonly bool silent;
        readonly bool is64Bit = Marshal.SizeOf(typeof(IntPtr)) == 8;
        readonly string[] type = { "Б", "КБ", "МБ", "ГБ" };
        readonly string ini = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Compact RAM Cleaner.ini";
        string GetSize(double countBytes)
        {
            double bytes = Math.Abs(countBytes);
            int place = (int)Math.Floor(Math.Log(bytes, 1024));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return $"{Math.Sign(countBytes) * num} {type[place]}";
        }
        async void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(ini))
            {
                File.ReadAllLines(ini).ToList().ForEach(x =>
                {
                    if (x.Contains("NotifyDisable=true")) checkBox4.Checked = true;
                    else if (x.Contains("ClearCache=true")) CacheCheck.Checked = true;
                    else if (x.Contains("AutoCleaner=true")) checkBox1.Checked = true;
                    else if (x.Contains("AutoCleanerValue=")) Numeric1.Value = Convert.ToDecimal(x.Remove(0, 17)) <= 95 ? Convert.ToDecimal(x.Remove(0, 17)) : 80;
                    else if (x.Contains("StartupCleaner=true")) { checkBox2.Checked = true; Ram(false); }
                    else if (x.Contains("Startup=true")) checkBox3.Checked = true;
                    else if (x.Contains("Language=en")) radioButton2.Checked = true;
                });
            }
            else { if (!CultureInfo.CurrentUICulture.ToString().Contains("ru-RU")) radioButton2.Checked = true; }

            if (!silent)
            {
                WindowState = FormWindowState.Normal;
                for (Opacity = 0; Opacity < 1; Opacity += .1)
                    await Task.Delay(5);
            }
            else
            {
                await Task.Delay(100);
                WindowState = FormWindowState.Minimized;
                Hide();
                Opacity = 1;
            }
        }
        async void Exit()
        {
            using (StreamWriter sw = File.CreateText(ini))
            {
                sw.WriteLine($"NotifyDisable={(checkBox4.Checked ? "true" : "false")}");
                sw.WriteLine($"ClearCache={(CacheCheck.Checked ? "true" : "false")}");
                sw.WriteLine($"AutoCleaner={(checkBox1.Checked ? "true" : "false")}");
                sw.WriteLine($"AutoCleanerValue={Numeric1.Value}");
                sw.WriteLine($"StartupCleaner={(checkBox2.Checked ? "true" : "false")}");
                sw.WriteLine($"Startup={(checkBox3.Checked ? "true" : "false")}");
                sw.WriteLine($"Language={(radioButton1.Checked ? "ru" : "en")}");
            }

            for (Opacity = 1; Opacity > .0; Opacity -= .1) await Task.Delay(10);
            Close();
        }
        void Lang()
        {
            if (radioButton2.Checked)
            {
                type[0] = "B";
                type[1] = "KB";
                type[2] = "MB";
                type[3] = "GB";
                LabelMon.Text = "Monitoring";
                LabelMon.Location = new Point(87, 21);
                label4.Text = "Usage:";
                label5.Text = "Total memory:";
                label6.Text = "Free memory:";
                Button1.Text = "Clean";
                CacheCheck.Text = "+ Cached";
                LabelSettings.Text = "Settings";
                LabelSettings.Location = new Point(95, 140);
                checkBox1.Text = "Auto purge on reaching (%)";
                checkBox2.Text = "Run cleanup on startup";
                checkBox3.Text = "Start at OS boot";
                checkBox4.Text = "Disable notification";
                Context1.Items[0].Text = "Сlear RAM";
                Context1.Items[1].Text = "Сlear RAM + Cached";
                Context1.Items[2].Text = "Exit";
                Label2.Text = $"{GetSize(TotalRam())}";
            }
            else
            {
                type[0] = "Б";
                type[1] = "КБ";
                type[2] = "МБ";
                type[3] = "ГБ";
                LabelMon.Text = "Мониторинг";
                LabelMon.Location = new Point(81, 21);
                label4.Text = "Занято:";
                label5.Text = "Всего памяти:";
                label6.Text = "Свободной памяти:";
                Button1.Text = "Очистить";
                CacheCheck.Text = "+ кэш ОЗУ";
                LabelSettings.Text = "Настройки";
                LabelSettings.Location = new Point(85, 140);
                checkBox1.Text = "Автоочистка при достижении (%)";
                checkBox2.Text = "Запускать очистку при запуске";
                checkBox3.Text = "Запускать при загрузке ОС";
                checkBox4.Text = "Отключить уведомление";
                Context1.Items[0].Text = "Очистка ОЗУ";
                Context1.Items[1].Text = "Очистка ОЗУ + кэш";
                Context1.Items[2].Text = "Выход";
                Label2.Text = $"{GetSize(TotalRam())}";
            }
        }

        void Ram(bool auto)
        {
            if (!auto) ram = FreeRam();
            Process.GetProcesses().ToList().ForEach(x => { try { EmptyWorkingSet(x.Handle); } catch { } });
            if (CacheCheck.Checked) ClearCache();
            if (!auto && !checkBox4.Checked) Popup.Show($"{(radioButton1.Checked ? "Освободилось" : "Freed")} {GetSize(FreeRam() - ram)}");
        }
        async void AutoCleaner()
        {
            while (checkBox1.Checked)
            {
                if (num >= Numeric1.Value)
                    Ram(true);
                await Task.Delay(30000);
            }
        }
        async void Tray()
        {
            while (true)
            {
                num = (TotalRam() - FreeRam()) * 100 / TotalRam();
                Label1.Text = $"{num}%";
                Label3.Text = $"{GetSize(FreeRam())}";
                Bitmap b = new Bitmap(16, 16);
                Graphics g = Graphics.FromImage(b);
                g.FillRectangle(new LinearGradientBrush(new Rectangle(1, 1, 15, 15), Color.FromArgb(30, 255, 0), Color.FromArgb(200, 0, 0), 270F)
                {
                    InterpolationColors = new ColorBlend(3)
                    {
                        Colors = new Color[3] { Color.FromArgb(30, 255, 0), Color.FromArgb(255, 246, 0), Color.FromArgb(200, 0, 0) },
                        Positions = new float[3] { 0.0f, 0.3f, 1f }
                    }
                }, 0, 15 - 15 * (int)num / 100, 15, 15);
                g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                g.DrawString(num.ToString(), new Font("Tahoma", 8F), new SolidBrush(Color.Black), 0, 2);
                g.DrawString(num.ToString(), new Font("Tahoma", 8F), new SolidBrush(Color.White), 0, 1);
                Icon i = Icon.FromHandle(b.GetHicon());
                NotifyIcon1.Icon = i;
                DestroyIcon(i.Handle);
                await Task.Delay(1000);
            }
        }
        ulong TotalRam() => new ComputerInfo().TotalPhysicalMemory;
        ulong FreeRam() => new ComputerInfo().AvailablePhysicalMemory;
    }
}
