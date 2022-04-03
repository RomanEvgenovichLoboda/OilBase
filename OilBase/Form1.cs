using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OilBase
{
    public partial class Form1 : Form
    {
        double rez;
        double sum;
        double day_sum;
        string[] price;
        Timer vTimer = new Timer();
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "A-95", "A-92", "A-80", "ДТ" });
            price = new string[] { "37,46", "35,24", "32,75", "28,32" };
            vTimer.Tick += new EventHandler(Quest);
        } 
        void Quest (object obj, EventArgs e)
        {
            vTimer.Stop();
            DialogResult mesbox = MessageBox.Show("Следующий Клиент ?", "Конец", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(mesbox == DialogResult.OK)
            {
                day_sum += double.Parse(label10.Text);
                label14.Text = Convert.ToString(day_sum);
                Reset_Form();
            } 
            else
            {
                vTimer.Interval = Decimal.ToInt32(10000);
                vTimer.Start();
            }
        }
        void Reset_Form()
        {
            button1.Enabled = false;
            textBox2.Text = "0";
            textBox3.Text = "0,00";
            textBox5.Text = "0";
            textBox7.Text = "0";
            textBox9.Text = "0";
            textBox11.Text = "0";
            label6.Text = "0,00";
            label9.Text = "0,00";
            label10.Text = "0,00";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
        void Product_Price()
        {
            sum = 0;
            if (checkBox1.Checked)
            {
                if (double.TryParse(textBox5.Text, out rez) == true && rez > 0) { sum += double.Parse(textBox4.Text) * double.Parse(textBox5.Text); }
            }
            if (checkBox2.Checked)
            {
                if (double.TryParse(textBox7.Text, out rez) == true && rez > 0) { sum += double.Parse(textBox6.Text) * double.Parse(textBox7.Text); }
            }
            if (checkBox3.Checked)
            {
                if (double.TryParse(textBox9.Text, out rez) == true && rez > 0) { sum += double.Parse(textBox8.Text) * double.Parse(textBox9.Text); }
            }
            if (checkBox4.Checked)
            {
                if (double.TryParse(textBox11.Text, out rez) == true && rez > 0) sum += double.Parse(textBox10.Text) * double.Parse(textBox11.Text);
            }
            label9.Text = Convert.ToString(sum);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = price[comboBox1.SelectedIndex];
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = false;
            groupBox3.Text = "К Оплате";
            label7.Text = "грн.";
            button1.Enabled = true;
            if (double.TryParse(textBox2.Text, out rez) == true && rez > 0) { label6.Text = Convert.ToString(double.Parse(textBox1.Text) * double.Parse(textBox2.Text)); }
            else { label6.Text = "0,00"; }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = true;
            groupBox3.Text = "К Выдаче";
            label7.Text = "л.";
            button1.Enabled = true;
            if (double.TryParse(textBox3.Text, out rez) == true && rez > 0) { label6.Text = Convert.ToString(Math.Round((double.Parse(textBox3.Text) / double.Parse(textBox1.Text)), 2)); }
            else { label6.Text = "0,00"; }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox2.Text, out rez) == true && rez > 0) { label6.Text = Convert.ToString(double.Parse(textBox1.Text) * double.Parse(textBox2.Text)); }
            else { label6.Text = "0,00"; }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox3.Text, out rez) == true && rez > 0) { label6.Text = Convert.ToString(Math.Round((double.Parse(textBox3.Text) / double.Parse(textBox1.Text)),2)); }
            else { label6.Text = "0,00"; }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { textBox5.Enabled = true; }
            else textBox5.Enabled = false;
            Product_Price();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { textBox7.Enabled = true; }
            else textBox7.Enabled = false;
            Product_Price();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true) { textBox9.Enabled = true; }
            else textBox9.Enabled = false;
            Product_Price();
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) { textBox11.Enabled = true; }
            else textBox11.Enabled = false;
            Product_Price();
        }
        private void textBox5_TextChanged(object sender, EventArgs e) { Product_Price(); }
        private void textBox7_TextChanged(object sender, EventArgs e) { Product_Price(); }
        private void textBox9_TextChanged(object sender, EventArgs e) { Product_Price(); }
        private void textBox11_TextChanged(object sender, EventArgs e) { Product_Price(); }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { label10.Text = Convert.ToString(Math.Round((sum + double.Parse(label6.Text)), 2)); }
            if (radioButton2.Checked == true) { label10.Text = Convert.ToString(Math.Round((sum + double.Parse(textBox3.Text)), 2)); }
            vTimer.Interval = Decimal.ToInt32(1000);
            vTimer.Start();
        }
    }
}