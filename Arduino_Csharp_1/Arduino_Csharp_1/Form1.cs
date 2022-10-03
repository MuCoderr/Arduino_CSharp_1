using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Arduino_Csharp_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String[] portlar = SerialPort.GetPortNames();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string port in portlar)
            {
                comboBox1.Items.Add(port);
                comboBox1.SelectedIndex = 0;
                label3.Text = "Bağlantı Kapalı!";
                label3.ForeColor = Color.Red;
                label1.Visible = false;
                label3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                label3.Visible = true;
                label3.Text = "Bağlantı Kapalı!";
                label3.ForeColor = Color.Red;
            }
            else
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                label3.Visible = true;
                label3.Text = "Bağlantı Açık!";
                label3.ForeColor = Color.Green;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                serialPort1.Write("1");
                label1.Visible = true;
                label1.Text = "Led Açık";
                label1.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Seri Port Bağlantısı Yok. Lütfen Bağlantınızı Kontrol Edin.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("0");
                label1.Visible = true;
                label1.Text = "Led Kapalı";
                label1.ForeColor = Color.Red;
            }
            else
            {
                MessageBox.Show("Seri Port Bağlantısı Yok. Lütfen Bağlantınızı Kontrol Edin.");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }
    }
}
