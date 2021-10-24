
namespace Compact_RAM_Cleaner
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.Context1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Button1 = new System.Windows.Forms.Button();
            this.CacheCheck = new System.Windows.Forms.CheckBox();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.AppName = new System.Windows.Forms.Label();
            this.Minimize = new System.Windows.Forms.Panel();
            this.ClosePanel = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.LabelMon = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Numeric1 = new System.Windows.Forms.NumericUpDown();
            this.LabelSettings = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Context1.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric1)).BeginInit();
            this.SuspendLayout();
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.ContextMenuStrip = this.Context1;
            this.NotifyIcon1.Text = "Compact RAM Cleaner";
            this.NotifyIcon1.Visible = true;
            // 
            // Context1
            // 
            this.Context1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu1,
            this.Menu3,
            this.Menu2});
            this.Context1.Name = "Context1";
            this.Context1.Size = new System.Drawing.Size(190, 70);
            // 
            // Menu1
            // 
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(189, 22);
            this.Menu1.Text = "Очистить ОЗУ";
            // 
            // Menu3
            // 
            this.Menu3.Name = "Menu3";
            this.Menu3.Size = new System.Drawing.Size(189, 22);
            this.Menu3.Text = "Очистить ОЗУ + кэш";
            // 
            // Menu2
            // 
            this.Menu2.Name = "Menu2";
            this.Menu2.Size = new System.Drawing.Size(189, 22);
            this.Menu2.Text = "Выход";
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.Silver;
            this.Button1.FlatAppearance.BorderSize = 0;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.ForeColor = System.Drawing.Color.Black;
            this.Button1.Location = new System.Drawing.Point(14, 110);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(134, 20);
            this.Button1.TabIndex = 14;
            this.Button1.Text = "Очистить";
            this.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button1.UseVisualStyleBackColor = false;
            // 
            // CacheCheck
            // 
            this.CacheCheck.AutoSize = true;
            this.CacheCheck.Location = new System.Drawing.Point(154, 113);
            this.CacheCheck.Name = "CacheCheck";
            this.CacheCheck.Size = new System.Drawing.Size(55, 17);
            this.CacheCheck.TabIndex = 26;
            this.CacheCheck.Text = "+ кэш";
            this.CacheCheck.UseVisualStyleBackColor = true;
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.TitlePanel.Controls.Add(this.AppName);
            this.TitlePanel.Controls.Add(this.Minimize);
            this.TitlePanel.Controls.Add(this.ClosePanel);
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(250, 18);
            this.TitlePanel.TabIndex = 25;
            // 
            // AppName
            // 
            this.AppName.AutoSize = true;
            this.AppName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.AppName.Location = new System.Drawing.Point(3, 2);
            this.AppName.Name = "AppName";
            this.AppName.Size = new System.Drawing.Size(115, 13);
            this.AppName.TabIndex = 33;
            this.AppName.Text = "Compact RAM Cleaner";
            // 
            // Minimize
            // 
            this.Minimize.Location = new System.Drawing.Point(208, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(18, 18);
            this.Minimize.TabIndex = 32;
            this.Minimize.Paint += new System.Windows.Forms.PaintEventHandler(this.Minimize_Paint);
            // 
            // ClosePanel
            // 
            this.ClosePanel.Location = new System.Drawing.Point(229, -1);
            this.ClosePanel.Name = "ClosePanel";
            this.ClosePanel.Size = new System.Drawing.Size(18, 18);
            this.ClosePanel.TabIndex = 31;
            this.ClosePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ClosePanel_Paint);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(122, 47);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "Память";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(122, 66);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(46, 13);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "Память";
            // 
            // LabelMon
            // 
            this.LabelMon.AutoSize = true;
            this.LabelMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMon.Location = new System.Drawing.Point(81, 21);
            this.LabelMon.Name = "LabelMon";
            this.LabelMon.Size = new System.Drawing.Size(87, 17);
            this.LabelMon.TabIndex = 30;
            this.LabelMon.Text = "Мониторинг";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(122, 86);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(46, 13);
            this.Label3.TabIndex = 29;
            this.Label3.Text = "Память";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Занято:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Всего памяти:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Свободной памяти:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.checkBox1.Location = new System.Drawing.Point(14, 165);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(192, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Автоочистка при достижении (%)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Numeric1
            // 
            this.Numeric1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.Numeric1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Numeric1.ForeColor = System.Drawing.SystemColors.Control;
            this.Numeric1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Numeric1.Location = new System.Drawing.Point(205, 165);
            this.Numeric1.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.Numeric1.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Numeric1.Name = "Numeric1";
            this.Numeric1.Size = new System.Drawing.Size(44, 16);
            this.Numeric1.TabIndex = 24;
            this.Numeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Numeric1.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // LabelSettings
            // 
            this.LabelSettings.AutoSize = true;
            this.LabelSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSettings.Location = new System.Drawing.Point(85, 140);
            this.LabelSettings.Name = "LabelSettings";
            this.LabelSettings.Size = new System.Drawing.Size(79, 17);
            this.LabelSettings.TabIndex = 38;
            this.LabelSettings.Text = "Настройки";
            // 
            // Panel1
            // 
            this.Panel1.Location = new System.Drawing.Point(233, 159);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(15, 26);
            this.Panel1.TabIndex = 34;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.checkBox3.Location = new System.Drawing.Point(15, 211);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(167, 17);
            this.checkBox3.TabIndex = 40;
            this.checkBox3.Text = "Запускать при загрузке ОС";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.checkBox2.Location = new System.Drawing.Point(14, 188);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(186, 17);
            this.checkBox2.TabIndex = 41;
            this.checkBox2.Text = "Запускать очистку при запуске";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.checkBox4.Location = new System.Drawing.Point(15, 234);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(151, 17);
            this.checkBox4.TabIndex = 42;
            this.checkBox4.Text = "Отключить уведомление";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 257);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 43;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Русский";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(88, 257);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 44;
            this.radioButton2.Text = "English";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(248, 285);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Numeric1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.LabelSettings);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabelMon);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CacheCheck);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.Button1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Англ";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Context1.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon NotifyIcon1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.CheckBox CacheCheck;
        private System.Windows.Forms.ContextMenuStrip Context1;
        private System.Windows.Forms.ToolStripMenuItem Menu1;
        private System.Windows.Forms.ToolStripMenuItem Menu2;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Panel Minimize;
        private System.Windows.Forms.Panel ClosePanel;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label LabelMon;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown Numeric1;
        private System.Windows.Forms.Label LabelSettings;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label AppName;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ToolStripMenuItem Menu3;
    }
}

