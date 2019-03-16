using MetroFramework.Controls;
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

namespace MetroCourseWork
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        int TBox;
        int val1;
        string text = "";
        string userText = "";
        int[] array = new int[10];

        public Form2()
        {
            InitializeComponent();

            this.StyleManager = metroStyleManager1;
            ControlBox = false;

            if (!File.Exists("linear.txt"))
            {
                File.Create("linear.txt").Close();
                File.WriteAllText("linear.txt", "1 6 3 5 7 3 4 2 0 5");
            }
            else
            {
                text = File.ReadAllText("linear.txt");
                array = text.Split(' ').Select(int.Parse).ToArray();
            }

            //int k = array.Length;
            int k = 0;
            foreach (var label in Controls.OfType<Label>())
            {
                int number;

                bool result = Int32.TryParse(label.Text, out number);
                if (result)
                {
                    //label.Text = Convert.ToString(array[k - 1]);
                    //k--;
                    label.Text = Convert.ToString(array[k]);
                    k++;
                    Update();
                }
            }
        }

        private void metroTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            int number;
            bool result = Int32.TryParse(metroTextBox1.Text, out number);
            if (result)
            {
                TBox = Convert.ToInt32(metroTextBox1.Text);
                TBox = int.Parse(metroTextBox1.Text);
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Control label in this.Controls)
            {
                if (label is MetroLabel)
                {
                    /*x.Text = "loololo";
                    x.BackColor = Color.AliceBlue;
                    ((MetroLabel)x).Text = "loololo";
                    ((MetroLabel)x).BackColor = Color.ForestGreen;*/
                    int number;
                    bool result = Int32.TryParse(label.Text, out number);
                    if (result)
                    {
                        val1 = Convert.ToInt32(label.Text);
                        if (TBox == val1)
                        {
                            label.ForeColor = Color.FromArgb(0, 204, 255);
                            Update();
                            System.Threading.Thread.Sleep(1000);
                            label.BackColor = Color.PowderBlue;
                            label.ForeColor = Color.Navy;
                            found = true;
                        }
                        else
                        {
                            label.ForeColor = Color.FromArgb(0, 204, 255); ;
                            Update();
                            System.Threading.Thread.Sleep(1000);
                            label.ForeColor = Color.Black;
                        }
                        Update();
                        System.Threading.Thread.Sleep(1250);
                    }
                }
            }
            if (found == true)
            {
                metroLabel11.ForeColor = Color.DarkGreen;
                metroLabel11.Text = "Значение найдено";

            }
            else
            {
                metroLabel11.ForeColor = Color.DarkRed;
                metroLabel11.Text = "Значение не найдено";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form1.Show();

            //this.Close();
        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            userText = metroTextBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //array = userText.Split(' ').Select(int.Parse).ToArray();
            bool noValid = false;
            bool overflow = false;
            String values = userText;
            Char delimiter = ' ';
            String[] substrings = values.Split(delimiter);

            int p = 0;
            foreach (var value in substrings)
            {
                int number;
                int temp;

                bool result = Int32.TryParse(value, out number);
                if (result)
                {
                    
                    if (p < 10)
                    {
                        Console.WriteLine("Converted '{0}' to {1}.", value, number);
                        temp = Convert.ToInt32(value);

                        if((temp>=-99) && (temp <= 99)){
                            array[p] = temp;
                        }
                        else
                        {
                            if (temp <-99)
                            {
                                array[p] = -99;
                            }
                            else if (temp > 99)
                            {
                                array[p] = 99;
                            }
                        }
                        p++;
                    }
                    else
                        overflow = true;
                }
                else
                {
                    noValid = true;
                    Console.WriteLine("Attempted conversion of '{0}' failed.",
                                       value == null ? "<null>" : value);
                }
            }

            if (overflow == true)
                MetroFramework.MetroMessageBox.Show(this, "Too many values entered. Please enter 10 (or less) integers in the range from -99 to 99.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (noValid == true)
                MetroFramework.MetroMessageBox.Show(this, "The entered value is not an integer. Please enter 10 (or less) integers in the range from -99 to 99.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //int k = array.Length;
            int k = 0;
            foreach (var label in Controls.OfType<Label>())
            {
                int number;

                bool result = Int32.TryParse(label.Text, out number);
                if (result)
                {
                    //label.Text = Convert.ToString(array[k - 1]);
                    //k--;
                    label.Text = Convert.ToString(array[k]);
                    k++;
                    Update();
                }
            }
        }
    }
}
