using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace DoNotDirectShow
{
    public partial class MainForm : Form
    {
        public static MainForm sInstance;
        public MainForm()
        {
            InitializeComponent();
            sInstance = this;
        }

        bool active = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            CaptureCard.Create(cboCCard);
            toolStripStatusLabel1.Text = "Initialized";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {         
            CaptureCard.Start(cboCCard);
            toolStripStatusLabel1.Text = "Started Capture Card";
            active = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CaptureCard.Stop();
            active = false;
        }

        public void SetStatusText(string val)
        {
            toolStripStatusLabel1.Text = val;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            CaptureCard.Stop();
            active = false;
            toolStripStatusLabel1.Text = "Stopped Capture Card";
        }

        private void btnScrnShot_Click(object sender, EventArgs e)
        {
            if(active)
                CaptureCard.ScreenShot();
            else
                toolStripStatusLabel1.Text = "Capture card is not Active!";
        }
    }
}
