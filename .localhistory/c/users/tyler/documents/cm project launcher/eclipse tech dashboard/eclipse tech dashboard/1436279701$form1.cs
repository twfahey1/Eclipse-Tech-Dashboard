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

namespace Eclipse_Tech_Dashboard
{
    public partial class Form1 : Form
    {
        string eclipse6helpPropertyName = "eclipse_6_help";
        string eclipse7helpPropertyName = "eclipse_7_help";
        string goldminePropertyName = "goldmine_path";
        string megalistPropertyName = "megalist_path";
        string eclipse6PropertyName = "eclipse_6_path";
        string eclipse7PropertyName = "eclipse_7_path";

        string Eclipse6HelpFilePath = Properties.Settings.Default["eclipse_6_help"].ToString();
        string Eclipse7HelpFilePath = Properties.Settings.Default["eclipse_7_help"].ToString();
        string GoldmineFilePath = Properties.Settings.Default["goldmine_path"].ToString();
        string MegalistFilePath = Properties.Settings.Default["megalist_path"].ToString();
        string Eclipse6FilePath = Properties.Settings.Default["eclipse_6_path"].ToString();
        string Eclipse7FilePath = Properties.Settings.Default["eclipse_7_path"].ToString();

        private ContextMenu trayMenu;
        private NotifyIcon trayIcon;
       
        private void SaveSetting(string setting, string change)
        {
            Properties.Settings.Default[setting] = change;
            Properties.Settings.Default.Save();
        }

        private void startfile(string path)
        {
            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.UseShellExecute = true;
            process.Start();

        }

        public Form1()
        {
            InitializeComponent();
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Eclipse 6 Help", Eclipse6HelpBtn_Click);
            trayMenu.MenuItems.Add("Eclipse 7 Help", Eclipse7HelpBtn_Click);
            trayMenu.MenuItems.Add("Goldmine", goldmineBtn_Click);
            trayMenu.MenuItems.Add("Megalist", megalistBtn_Click);
            trayMenu.MenuItems.Add("Eclipse 6", eclipse6Btn_Click);
            trayMenu.MenuItems.Add("Eclipse 7", eclipse7Btn_Click);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Show App", ShowApp);
            trayMenu.MenuItems.Add("Exit", exitBtn_Click);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Eclipse Tech Dashboard";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

        }

        private void Eclipse6HelpBtn_Click(object sender, EventArgs e)
        {
            startfile(Eclipse6HelpFilePath);
        }

        private void Eclipse7HelpBtn_Click(object sender, EventArgs e)
        {
            startfile(Eclipse7HelpFilePath);
        }

        private void megalistBtn_Click(object sender, EventArgs e)
        {
            startfile(MegalistFilePath);

        }

        private void goldmineBtn_Click(object sender, EventArgs e)
        {
            startfile(GoldmineFilePath);
        }

        private void ModEclipse6HelpBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Eclipse6HelpFilePath = openFileDialog1.FileName;
                SaveSetting(eclipse6helpPropertyName, Eclipse6HelpFilePath);
            }

        }

        private void ModEclipse7HelpBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Eclipse7HelpFilePath = openFileDialog1.FileName;
                SaveSetting(eclipse7helpPropertyName, Eclipse7HelpFilePath);
            }

        }

        private void modMegaListBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MegalistFilePath = openFileDialog1.FileName;
                SaveSetting(megalistPropertyName, MegalistFilePath);
            }
        }

        private void modGoldmineBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GoldmineFilePath = openFileDialog1.FileName;
                SaveSetting(goldminePropertyName, GoldmineFilePath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            System.Environment.Exit(1);
        }

        private void Dispose_Icons(object sender, FormClosingEventArgs e)
        {
            trayIcon.Dispose();
        }

        private void eclipse6Btn_Click(object sender, EventArgs e)
        {
            startfile(Eclipse6FilePath);
        }

        private void eclipse7Btn_Click(object sender, EventArgs e)
        {
            startfile(Eclipse7FilePath);
        }

        private void modEclipse6btn_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Eclipse6FilePath = openFileDialog1.FileName;
                SaveSetting(eclipse6PropertyName, Eclipse6FilePath);
            }
        }

        private void modEclipse7Btn_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Eclipse7FilePath = openFileDialog1.FileName;
                SaveSetting(eclipse7PropertyName, Eclipse7FilePath);
            }
        }

    }
}
