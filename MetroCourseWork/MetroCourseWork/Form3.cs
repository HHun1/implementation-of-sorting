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
using MetroFramework.Controls;

namespace MetroCourseWork
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        int TBox;
        int[] array = new int[10];
        string text = "";
        string userText = "";
        bool sorted = true;

        public Form3()
        {
            InitializeComponent();

            this.StyleManager = metroStyleManager1;
            ControlBox = false;
            int k = array.Length;

            if (!File.Exists("binary.txt"))
            {
                File.Create("binary.txt").Close();
                File.WriteAllText("binary.txt", "1 2 3 5 7 8 9 10 11 16");
            }
            else
            {
                text = File.ReadAllText("binary.txt");
                array = text.Split(' ').Select(int.Parse).ToArray();
            }

            foreach (var label in Controls.OfType<Label>())
            {
                int number;

                bool result = Int32.TryParse(label.Text, out number);
                if (result)
                {
                    {
                        label.Text = Convert.ToString(array[k - 1]);
                        k--;
                        Update();
                    }
                }
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool result = Int32.TryParse(metroTextBox1.Text, out number);
            if (result)
            {
                TBox = Convert.ToInt32(metroTextBox1.Text);
                TBox = int.Parse(metroTextBox1.Text);
            }
        }

        private int? BinarySearch(int[] a, int x)
        {
            if ((a.Length == 0) || (x < a[0]) || (x > a[a.Length - 1]))
                return null;

            int first = 0;
            // Номер элемента массива, СЛЕДУЮЩЕГО за последним
            int last = a.Length;

            while (first < last)
            {
                int mid = first + (last - first) / 2;
                foreach (Control label in this.Controls)
                {
                    if (label is MetroLabel)
                    {
                        if((label.TabIndex == mid) && (label.TabIndex < 10))
                        {
                            label.ForeColor = Color.FromArgb(0, 204, 255);
                            Update();
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                }

                if (x <= a[mid])
                {
                    last = mid;
                    foreach (Control label in this.Controls)
                    {
                        if (label is MetroLabel)
                        {
                            if ((label.TabIndex > mid) && (label.TabIndex < 10))
                            {
                                label.Visible = false;
                                Update();
                            }
                            else
                            {
                                label.ForeColor = Color.Black;
                                label.BackColor = Color.White;
                                Update();
                            }
                        }
                    }
                }
                else
                {
                    first = mid + 1;
                    foreach (Control label in this.Controls)
                    {
                        if (label is MetroLabel)
                        {
                            if ((label.TabIndex < mid) && (label.TabIndex < 10))
                            {
                                label.Visible = false;
                                Update();
                            }
                            else
                            {
                                label.ForeColor = Color.Black;
                                label.BackColor = Color.White;
                                Update();
                            }
                        }
                    }
                }
                if ((last != 10)&& (a[last] == x))
                    break;
            }

            // Теперь last может указывать на искомый элемент массива.
            if (a[last] == x)
                return last;
            else
                return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form1.Show();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control label in this.Controls)
            {
                if (label is MetroLabel)
                {
                    label.ForeColor = Color.Black;
                    label.BackColor = Color.White;
                    metroLabel11.Visible = false;
                }
            }
            //array = userText.Split(' ').Select(int.Parse).ToArray();
            bool noValid = false;
            bool overflow = false;
            String values = userText;
            Char delimiter = ' ';
            String[] substrings = values.Split(delimiter);
            foreach (var substring in substrings)
            {
                Console.WriteLine(substring);
            }

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

                        if ((temp >= -99) && (temp <= 99))
                        {
                            array[p] = temp;
                        }
                        else
                        {
                            if (temp < -99)
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

            sorted = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1]) sorted = false;
            }

            if (overflow == true)
                MetroFramework.MetroMessageBox.Show(this, "Too many values entered. Please enter 10 (or less) integers in the range from -99 to 99.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (noValid == true)
                MetroFramework.MetroMessageBox.Show(this, "The entered value is not an integer. Please enter 10 (or less) integers in the range from -99 to 99.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (sorted == false)
                MetroFramework.MetroMessageBox.Show(this, "The array is not sorted. Please enter values again. The search will not be performed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            int k = array.Length;
            foreach (var label in Controls.OfType<Label>())
            {
                int number;

                bool result = Int32.TryParse(label.Text, out number);
                if (result)
                {
                    label.Text = Convert.ToString(array[k - 1]);
                    k--;
                    Update();
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int count = 0;
            bool found = false;
            
            int? index;
            index = BinarySearch(array, TBox);
            
            foreach (Control label in this.Controls)
            {
                if (label is MetroLabel)
                {
                    label.ForeColor = Color.Black;
                    label.BackColor = Color.White;
                    label.Visible = true;
                }
            }

            foreach (Control label in this.Controls)
            {
                if (label is MetroLabel)
                {
                    int number;
                    if (index != null)
                    {
                        found = true;

                        bool result = Int32.TryParse(label.Text, out number);
                        if (result)
                        {
                            count++;
                            if (count == (10 - index))
                            {
                                label.Visible = true;
                                label.BackColor = Color.PowderBlue;
                                label.ForeColor = Color.Navy;
                                Update();
                            }
                        }
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
                if (sorted == false)
                {
                    metroLabel11.Visible = false;
                }
                if (sorted == true)
                {
                    metroLabel11.Visible = true;
                    metroLabel11.ForeColor = Color.DarkRed;
                    metroLabel11.Text = "Значение не найдено";
                }
            }
        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            userText = metroTextBox2.Text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
