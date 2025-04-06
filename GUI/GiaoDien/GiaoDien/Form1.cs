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
using System.IO.Ports;
using System.Xml;
using System.Threading;
namespace GiaoDien
{
    public partial class Form1 : Form
    {
        string ReceiveData = String.Empty;
        string TransmitData = String.Empty;
        bool test_sta = false;
        private StringBuilder receivedBuffer = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort.PortName = "Select COM Port...";
            serialPort.BaudRate = 4800;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            //Doc thong tin cac cong COM co trong PC
            string[] ports = SerialPort.GetPortNames();
            //Them ten  cua tat ca cac cong vao muc COM Port
            foreach (string port in ports)
            {
                comboBox_com.Items.Add(port);
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }
        private void textBox_status_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if (comboBox_com.Text == "")
                MessageBox.Show("Select COM Port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //Xu ly mo cong COM da chon
                try
                {
                    if (serialPort.IsOpen) //xu ly truong hop da ket noi
                    {
                        MessageBox.Show("COM Port is connected and ready for use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else //xu ly truong hop chua ket noi
                    {
                        serialPort.Open(); //Mo cong COM
                        MessageBox.Show(comboBox_com.Text + " is connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_status.BackColor = Color.Lime; //Hieu chinh mau va thong tin
                        textBox_status.Text = "Connected";
                        comboBox_com.Enabled = false;

                        ReceiveData = String.Empty;
                        TransmitData = String.Empty;
                    }
                }

                catch (Exception) // Xu ly xuat hien loi khong thay thiet bi
                {
                    textBox_status.BackColor = Color.Red;
                    textBox_status.Text = "Disconnected";
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen) //Xu ly truong hop da ket noi
                {
                    serialPort.Close();
                    textBox_status.BackColor = Color.Red;
                    textBox_status.Text = "Disconnected!";
                    MessageBox.Show("COM port is disconnected!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox_com.Enabled = true;
                }
                else //xu ly truong hop chua ket noi
                {
                    MessageBox.Show("COM port have been disconnected. Please reconnect to use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception) // xu ly khi xuat hien loi
            {
                MessageBox.Show("Disconnection appears error. Unable to disconnect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            TransmitData = textBox_send.Text;
            serialPort.Write(TransmitData);
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort.ReadExisting();
            
            this.Invoke(new Action(() =>
            {
                textBox_receive.AppendText(receivedData);
            }));

            if (test_sta)
            {
                receivedBuffer.Append(receivedData);
                int ampersandCount = receivedBuffer.ToString().Count(c => c == '&');

                // Cập nhật giao diện hiển thị số ký tự '&'
                this.Invoke(new Action(() =>
                {
                    textBox_ampersandCount.Text = ampersandCount.ToString();
                }));

                // Nếu tổng ký tự đã nhận được đủ 100, kết thúc kiểm tra
                if (receivedBuffer.Length >= 100)
                {
                    test_sta = false; // Tắt chế độ kiểm tra
                    receivedBuffer.Clear(); // Xóa bộ đệm
                }
            }
        }


        private void comboBox_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Xu ly khi chon cong COM
            serialPort.Close();
            textBox_status.BackColor = Color.Red;
            textBox_status.Text = "Disconnected!";
            serialPort.PortName = comboBox_com.Text;
        }

        private void textBox_send_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_test_Click(object sender, EventArgs e)
        {
            test_sta = true;
            TransmitData = "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&";
            serialPort.Write(TransmitData);
        }

        private void button_exit(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Ban co muon thoat chuong trinh khong?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                this.Close();
            }
        }

        private void button_clear(object sender, EventArgs e)                                                   
        {
            textBox_receive.Text = " ";
        }
    }
}
 