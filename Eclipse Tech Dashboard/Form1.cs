using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Eclipse_Tech_Dashboard
{
    public partial class Form1 : Form
    {
        string Btn1Path;
        string Btn1Label;
        string Btn2Path;
        string Btn2Label;
        string Btn3Path;
        string Btn3Label;
        string Btn4Path;
        string Btn4Label;
        string Btn5Path;
        string Btn5Label;

        private ContextMenu trayMenu;
        private NotifyIcon trayIcon;

        public Form1()
        {
            InitializeComponent();
            InitializeButtons();
            RebuildTaskbarMenu();
        }

        private void InitializeButtons()
        {
            Btn1Path = Properties.Settings.Default["Btn1Path"].ToString();
            Btn1Label = Properties.Settings.Default["Btn1"].ToString();
            Btn1.Text = Btn1Label;
            Btn2Path = Properties.Settings.Default["Btn2Path"].ToString();
            Btn2Label = Properties.Settings.Default["Btn2"].ToString();
            Btn2.Text = Btn2Label;
            Btn3Path = Properties.Settings.Default["Btn3Path"].ToString();
            Btn3Label = Properties.Settings.Default["Btn3"].ToString();
            Btn3.Text = Btn3Label;
            Btn4Path = Properties.Settings.Default["Btn4Path"].ToString();
            Btn4Label = Properties.Settings.Default["Btn4"].ToString();
            Btn4.Text = Btn4Label;
            Btn5Path = Properties.Settings.Default["Btn5Path"].ToString();
            Btn5Label = Properties.Settings.Default["Btn5"].ToString();
            Btn5.Text = Btn5Label;
        }

        private void RebuildTaskbarMenu()
        {
            /*This first checks if we have a tray icon already so we can toggle it off */
            if (trayIcon != null)
            {
                trayIcon.Visible = false;
                trayMenu.Dispose();
                trayIcon.Dispose();
            }
            
            /*Set up and build tray menu */
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add(Btn1.Text, Btn1_Click);
            trayMenu.MenuItems.Add(Btn2.Text, Btn2_Click);
            trayMenu.MenuItems.Add(Btn3.Text, Btn3_Click);
            trayMenu.MenuItems.Add(Btn4.Text, Btn4_Click);
            trayMenu.MenuItems.Add(Btn3.Text, Btn3_Click);

            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Show App", ShowApp);
            trayMenu.MenuItems.Add("Exit", exitBtn_Click);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Eclipse Tech Dashboard";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;


        }

        private void SaveSetting(string setting, string change)
        {
            Properties.Settings.Default[setting] = change;
            Properties.Settings.Default.Save();
            InitializeButtons();
            RebuildTaskbarMenu();

        }

        private void StartFile(string path)
        {
            try
            {

                Process process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.UseShellExecute = true;
                process.Start();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void hideInTray_Click(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
        }

        private void ShowApp(object sender, EventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            trayIcon.Dispose();
            trayMenu.Dispose();
            this.Close();
        }

        private void RenameButton(Button btn)
        {
            ChangeNameForm chgForm = new ChangeNameForm();
            chgForm.ActiveChangingBtn = btn.Name;
            if (chgForm.ShowDialog() == DialogResult.OK)
            {
                btn.Text = Properties.Settings.Default[btn.Name.ToString()].ToString();

            }
            RebuildTaskbarMenu();
        }

        private void ChangePath(Button btn, string newPath)
        {

            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                newPath = openFileDialog1.FileName;
                SaveSetting(btn.Name.ToString() + "Path", newPath);

                InitializeButtons();
            }
        }

        private void RenameBtn1_Click(object sender, EventArgs e)
        {
            
            RenameButton(Btn1);
        
        }

        private void ChangePath1Btn_Click(object sender, EventArgs e)
        {
            ChangePath(Btn1, Btn1Path);
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            StartFile(Btn1Path);
        }

        private void RenameBtn2_Click(object sender, EventArgs e)
        {
            RenameButton(Btn2);
        }

        private void ChangePath2Btn_Click(object sender, EventArgs e)
        {
            ChangePath(Btn2, Btn2Path);
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            StartFile(Btn2Path);
        }

        private void RenameBtn3_Click(object sender, EventArgs e)
        {
            RenameButton(Btn3);
        }

        private void ChangePath3Btn_Click(object sender, EventArgs e)
        {
            ChangePath(Btn3, Btn3Path);
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            StartFile(Btn3Path);
        }

        private void RenameBtn4_Click(object sender, EventArgs e)
        {
            RenameButton(Btn4);
        }

        private void ChangePath4Btn_Click(object sender, EventArgs e)
        {
            ChangePath(Btn4, Btn4Path);
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            StartFile(Btn4Path);
        }

        private void RenameBtn5_Click(object sender, EventArgs e)
        {
            RenameButton(Btn5);
        }

        private void ChangePath5Btn_Click(object sender, EventArgs e)
        {
            ChangePath(Btn5, Btn5Path);

        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            StartFile(Btn5Path);
        }

    }
}
