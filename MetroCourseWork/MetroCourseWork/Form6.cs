using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroCourseWork
{
    public partial class Form6 : MetroFramework.Forms.MetroForm
    {
        VScrollBar vbar;
        VScrollBar v2bar;

        public Form6()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;

            ControlBox = false;

            vbar = vScrollBar1;
            vbar.Parent = this.metroTabPage1;
            vbar.Value = 0;
            vbar.Maximum = 385;
            vbar.Minimum = 0;
            vbar.ValueChanged += new EventHandler(vScrollBar1_ValueChanged);

            v2bar = vScrollBar2;
            v2bar.Parent = this.metroTabPage2;
            v2bar.Value = 0;
            v2bar.Maximum = 345;
            v2bar.Minimum = 0;
            v2bar.ValueChanged += new EventHandler(vScrollBar2_ValueChanged);
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            metroLabel3.Location = new Point(metroLabel3.Left, -vbar.Value);
            metroLabel4.Location = new Point(metroLabel4.Left, -vbar.Value + 45);
            metroLabel5.Location = new Point(metroLabel5.Left, -vbar.Value + 205);
            metroLabel6.Location = new Point(metroLabel6.Left, -vbar.Value + 390);
        }

        private void vScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            metroLabel1.Location = new Point(metroLabel1.Left, -v2bar.Value);
            metroLabel7.Location = new Point(metroLabel7.Left, -v2bar.Value + 75);
            metroLabel8.Location = new Point(metroLabel8.Left, -v2bar.Value + 285);
            metroLabel9.Location = new Point(metroLabel9.Left, -v2bar.Value + 345);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form1.Show();
            //this.Close();
        }
    }
}
