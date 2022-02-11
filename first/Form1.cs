using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace first
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            firstDispley.Text = "";
            secondDispley.Text = "";
            Numbers.SetDictionary();

            foreach (var number in Numbers.SingleDigits)
            {
                richTextBox1.Text += number.Value + " " + number.Key + "\n";
            }
            foreach (var number in Numbers.TensDigits)
            {
                richTextBox2.Text += number.Value + " " + number.Key + "\n";
            }
            richTextBox2.Text += "17 dix sept\n18 dix huit\n19 dix neuf\n";
            foreach (var number in Numbers.DoubleDigits)
            {
                richTextBox3.Text += number.Value + " " + number.Key + "\n";
            }
            richTextBox3.Text += "70 soixante dix\n80 quatre vingts\n90 quatre vingt dix";

            richTextBox5.Text += "et - после дестков, перед un или onze\n" +
                "vingt - после quatre например: 81 - quatre vingt un\n" +
                "cent - сотня, например: 201 - deux cent un\n" +
                "81 - quatre vingt un\n" +
                "200 - deux cents";

        }

        private void button_Click(object sender, EventArgs e)
        {
            firstDispley.Text = "";
            secondDispley.Text = "";
            string error = Numbers.GetNumber(textBox.Text.ToLower());
            if(error == "")
            {
                if (Numbers.Number == 0)
                    firstDispley.Text = "Пустая строка";
                else
                    firstDispley.Text = Numbers.Number.ToString();
                secondDispley.Text = Numbers.OldNumber;
            }
            else
            {
                firstDispley.Text = error;
            }
        }
    }
}
