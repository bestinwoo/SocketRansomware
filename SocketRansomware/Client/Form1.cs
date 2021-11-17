using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketRansomware
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

        }

        private int duration = 36000;
        private int duration2 = 43200;
        DateTime dt;
        private void Form1_Load(object sender, EventArgs e)
        {
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
