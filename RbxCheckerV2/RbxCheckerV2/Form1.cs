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
            checkandkill();
            DialogResult = MessageBox.Show("*NOTE* This program does run in the background and does require rbxfpsunlocker.exe to be in the same directory as it, still run?", "NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.Yes)
            {
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
    }
}
