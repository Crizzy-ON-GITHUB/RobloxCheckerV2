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
using System.Net;

namespace RbxCheckerV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rdm = new Random();
            int chance = rdm.Next(1, 10);
            if (chance == 3)
            {
                MessageBox.Show("Thank you for using RbxCheckerV2!", "Thank you :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            checkandkill();
            checkforupdate();
            DialogResult = MessageBox.Show("*NOTE* This program does run in the background and does require rbxfpsunlocker.exe to be in the same directory as it, still run?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.Yes)
            {
                notifyIcon1.ShowBalloonTip(2000);
                timer1.Start();
                timer2.Start();
            }
            else
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            Process[] rfu = Process.GetProcessesByName("rbxfpsunlocker");
            Process[] rbx = Process.GetProcessesByName("RobloxPlayerBeta");

            if (rfu.Length == 0)
            {
                if (rbx.Length == 0)
                {
                }
                else
                {
                    if (File.Exists("rbxfpsunlocker.exe"))
                    {
                        Process.Start("rbxfpsunlocker.exe");
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter("log.txt"))
                        {
                            sw.WriteLine("*Error* rbxfpsunlocker.exe not found exited process");
                            sw.Close();
                        }
                        this.Close();
                    }
                }
            }
            else
            {
                return;
            }
        }
        void checkandkill()
        {
            Process[] rfu = Process.GetProcessesByName("rbxfpsunlocker");
            Process[] rbx = Process.GetProcessesByName("RobloxPlayerBeta");
            
            if (rfu.Length == 0)
            {
                return;
            }
            else
            {
                foreach (var p in Process.GetProcessesByName("rbxfpsunlocker"))
                {
                    p.Kill();
                }
            }
            if (rbx.Length == 0)
            {
                return;
            }
            else
            {
                foreach (var r in Process.GetProcessesByName("RobloxPlayerBeta"))
                {
                    r.Kill();
                }
            }
        }

        void checkforupdate()
        {
            try
            {
                WebClient updatechecker = new WebClient();
                string uc = updatechecker.DownloadString("https://crizzy-on-github.github.io/RobloxCheckerV2/version.txt");
                if (uc.Contains("0.4"))
                {
                    return;
                }
                else
                {
                    DialogResult = MessageBox.Show("Update available would you like to go to github?", "Update Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Process.Start("https://github.com/Crizzy-ON-GITHUB/RobloxCheckerV2/releases");
                        this.Close();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Process[] rfu = Process.GetProcessesByName("rbxfpsunlocker");
            Process[] rbx = Process.GetProcessesByName("RobloxPlayerBeta");

            if (rbx.Length == 0)
            {
                if (rfu.Length == 0)
                {
                    return;
                }
                else
                {
                    foreach (var p in Process.GetProcessesByName("rbxfpsunlocker"))
                    {
                        p.Kill();
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menucfu();
        }

        void menucfu()
        {
            try
            {
                WebClient updatechecker = new WebClient();
                string uc = updatechecker.DownloadString("https://raw.githubusercontent.com/Crizzy-ON-GITHUB/RobloxCheckerV2/main/version.txt");
                if (uc.Contains("0.4"))
                {
                    MessageBox.Show("No updates available at the moment!", "No Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult = MessageBox.Show("Update available would you like to go to github?", "Update Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Process.Start("https://github.com/Crizzy-ON-GITHUB/RobloxCheckerV2/releases");
                        this.Close();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void githubPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Crizzy-ON-GITHUB/RobloxCheckerV2");
        }
    }
}
