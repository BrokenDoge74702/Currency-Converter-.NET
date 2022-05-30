using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Currency_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] getCurrencyTags()
        {
            return new string[] { "EUR", "USD", "JPY", "IDR",
                "AUD", "CAD", "JPY", "SGD", "PHP", "MYR", "CNY" };
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(getCurrencyTags());
            comboBox2.Items.AddRange(getCurrencyTags());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = string.Format("https://api.apilayer.com/exchangerates_data/latest?base={0}&symbols={1}&apikey=GDimhYKJo2bY05G2DjNvdfjRpqmq2l5d", comboBox1.SelectedItem, comboBox2.SelectedItem);
            dynamic res = JObject.Parse(new
               WebClient().DownloadString(url));

            float rate = (float)res.rates[comboBox2.SelectedItem];
            textBox1.Text = ((float)numericUpDown1.Value *
                rate).ToString("0.00");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}