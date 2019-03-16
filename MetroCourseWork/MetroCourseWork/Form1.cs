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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

            this.StyleManager = metroStyleManager1;
            ControlBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            /*Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();*/

            //Globals.Field = ((RadioButton)sender).Text;

            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form2.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            /*Form3 f3 = new Form3();
            f3.Owner = this;
            f3.Show();*/

            Form3 form3 = new Form3();
            form3.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form3.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            /*Form4 f4 = new Form4();
            f4.Owner = this;
            f4.Show();*/

            Form4 form4 = new Form4();
            form4.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form4.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            /*Form5 f5 = new Form5();
            f5.Owner = this;
            f5.Show();*/

            Form5 form5 = new Form5();
            form5.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form5.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            /*Form6 f6 = new Form6();
            f6.Owner = this;
            f6.Show();*/

            Form6 form6 = new Form6();
            form6.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroTile1_MouseHover(object sender, EventArgs e)
        {
            metroTile1.BackColor = Color.LightSkyBlue;
        }

        private void metroTile1_MouseLeave(object sender, EventArgs e)
        {
            metroTile1.BackColor = Color.FromArgb(47, 122, 154);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void metroTile2_MouseHover(object sender, EventArgs e)
        {
            metroTile2.BackColor = Color.MediumSeaGreen;
        }

        private void metroTile2_MouseLeave(object sender, EventArgs e)
        {
            metroTile2.BackColor = Color.FromArgb(44, 115, 107);
        }

        private void metroTile4_MouseHover(object sender, EventArgs e)
        {
            metroTile4.BackColor = Color.Plum;
        }

        private void metroTile4_MouseLeave(object sender, EventArgs e)
        {
            metroTile4.BackColor = Color.FromArgb(148, 107, 133);
        }

        private void metroTile5_MouseHover(object sender, EventArgs e)
        {
            metroTile5.BackColor = Color.FromArgb(227, 208, 176);
        }

        private void metroTile5_MouseLeave(object sender, EventArgs e)
        {
            metroTile5.BackColor = Color.FromArgb(184, 166, 145);
        }

        private void metroTile3_MouseHover(object sender, EventArgs e)
        {
            metroTile3.BackColor = Color.MediumPurple;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.BackColor = Color.FromArgb(47, 41, 67);
        }
    }
}
