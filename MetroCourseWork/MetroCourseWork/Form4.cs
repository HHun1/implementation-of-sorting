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
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        public Form4()
        {
            InitializeComponent();

            this.StyleManager = metroStyleManager1;
            ControlBox = false;
        }

        private void metroToggle2_MouseClick(object sender, MouseEventArgs e)
        {
            this.webBrowser1.Navigate("https://ru.wikipedia.org/wiki/%D0%94%D0%B2%D0%BE%D0%B8%D1%87%D0%BD%D1%8B%D0%B9_%D0%BF%D0%BE%D0%B8%D1%81%D0%BA");
            if (metroToggle1.Checked == true)
                metroToggle1.Checked = false;
        }

        private void metroToggle1_MouseClick(object sender, MouseEventArgs e)
        {
            this.webBrowser1.Navigate("https://ru.wikipedia.org/wiki/%D0%9B%D0%B8%D0%BD%D0%B5%D0%B9%D0%BD%D1%8B%D0%B9_%D0%BF%D0%BE%D0%B8%D1%81%D0%BA");
            if (metroToggle2.Checked == true)
                metroToggle2.Checked = false;
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
