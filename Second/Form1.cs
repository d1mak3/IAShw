using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Second
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            string[] first = textBox1.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int firstNum, secondNum;
            List<string> firstStr = new List<string>();
            if (Int32.TryParse(textBox2.Text, out firstNum) == false)
            {
                textBox4.Text = "Неизвестное число " + textBox2.Text;
                return;
            }

            if (Int32.TryParse(textBox3.Text, out secondNum) == false)
            {
                textBox4.Text = "Неизвестное число " + textBox3.Text;
                return;
            }

            if (firstNum < 1)
            {
                textBox4.Text = "Число " + textBox2.Text + " должно быть не меньше единицы";
                return;
            }
            if (firstNum > first.Length)
            {
                textBox4.Text = "Число " + textBox2.Text + " должно быть не больше количества слов";
                return;
            }
            if (firstNum > secondNum)
            {
                textBox4.Text = "Число " + textBox3.Text + " должно быть не меньше первого числа";
                return;
            }
            if (secondNum > first.Length)
            {
                textBox4.Text = "Число " + textBox3.Text + " должно быть не больше количества слов";
                return;
            }
            foreach (var word in first)
            {
                firstStr.Add(word);
            }
            for (int i = firstNum; i <= secondNum; i++)
            {
                textBox4.Text += firstStr[firstNum - 1] + " ";
                firstStr.RemoveAt(firstNum - 1);
            }
            foreach (var word in firstStr)
            {
                textBox4.Text += word + " ";
            }
        }
    }
}
