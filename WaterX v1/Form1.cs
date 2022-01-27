using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WeAreDevs_API;
using System.Drawing.Drawing2D;

namespace WaterX_v1
{
    public partial class Form1 : Form
    {
        WeAreDevs_API.ExploitAPI api = new WeAreDevs_API.ExploitAPI();
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            api.SendLimitedLuaScript(fastColoredTextBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
            if(api.isAPIAttached())
            {
                button4.Text = "injected";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialogfile = new OpenFileDialog();
            opendialogfile.Filter = "Lua File (*.lua)|*.lua|Text File (*.txt)|*.txt";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                fastColoredTextBox1.Text = "";
                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;
                using (stream)
                    this.fastColoredTextBox1.Text = System.IO.File.ReadAllText(opendialogfile.FileName);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("can´t attach", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
        }

        private void AddTabButton_Click(object sender, EventArgs e)
        {
            TabPage newTab = new TabPage();
            FastColoredTextBoxNS.FastColoredTextBox textBox = new FastColoredTextBoxNS.FastColoredTextBox();
            newTab.Name = "Script" + (visualStudioTabControl1.TabCount + 1);
            newTab.Text = "New Tab  ";
            newTab.Parent = visualStudioTabControl1;
            textBox.Dock = DockStyle.Fill;
            textBox.Name = "fastColoredTextBox1";
            textBox.Parent = newTab;
            visualStudioTabControl1.SelectTab(newTab);
            AddTabButton.Left = AddTabButton.Left + 75;
            RemoveTabButton.Left = RemoveTabButton.Left + 77;
            if (visualStudioTabControl1.TabCount == 7)
            {
                AddTabButton.Hide();
            }
            if (visualStudioTabControl1.TabCount > 1)
            {
                RemoveTabButton.Show();
            }
        }

        private void RemoveTabButton_Click(object sender, EventArgs e)
        {
            if (visualStudioTabControl1.TabCount > 1)
            {
                Control tabPageToRemove = visualStudioTabControl1.Controls["Script" + (visualStudioTabControl1.TabCount)];
                visualStudioTabControl1.SelectTab("Script" + (visualStudioTabControl1.TabCount - 1));
                visualStudioTabControl1.Controls.Remove(tabPageToRemove);
                AddTabButton.Left = AddTabButton.Left - 75;
                RemoveTabButton.Left = RemoveTabButton.Left - 77;
                if (visualStudioTabControl1.TabCount == 7)
                {
                    AddTabButton.Hide();
                }
                else
                {
                    AddTabButton.Show();
                }
                if (visualStudioTabControl1.TabCount == 1)
                {
                    RemoveTabButton.Hide();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        public void fastColoredTextBox1_Load_1(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
        }
    }
}
