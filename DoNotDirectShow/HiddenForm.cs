using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoNotDirectShow
{
    public partial class HiddenForm : Form
    {
        public HiddenForm()
        {
            TopMost = true;
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            FormBorderStyle = FormBorderStyle.None;
            Opacity = 0.0; // because OBS doesn't support Opacity, it will show as normal            
        }

        bool disposed = false;
        bool shownMessage = false;

        private void HiddenForm_Load(object sender, EventArgs e)
        {
            shownMessage = false;
            disposed = false;
        }        

        public void UpdateImage(Image img)
        {
            if (!InvokeRequired)
            {
                if (disposed == false)
                {
                    if (ccPreview.Image != null)
                        ccPreview.Image.Dispose();
                    ccPreview.Image = img;
                    Size = ccPreview.Size = new Size(img.Width, img.Height); // update form size
                }
            }
            else
            {
                if (disposed == false)
                {
                    try // i don't really like how this is done but when i don't use a try catch then the program can crash, probably because of threads writing to disposed too late
                    {
                        Invoke(new Action<Image>(UpdateImage), img);
                    }
                    catch
                    {
                        MainForm.sInstance.SetStatusText("Capture card is stopped.");
                    }                    
                }
            }

            if (!shownMessage)
            {
                Size scrnSize = Screen.PrimaryScreen.Bounds.Size;
                Size imgSize = img.Size;
                string statusText = string.Empty;
                // add 12 to monitor resolution as this is the max working area
                if (imgSize.Height > (scrnSize.Height + 12))
                {
                    statusText = "Image resolution is higher than monitor resolution!";
                    MainForm.sInstance.SetStatusText("Out of Bounds!");
                    int adjustment = (imgSize.Height - (scrnSize.Height + 12)) / 2;
                    ccPreview.Top = -adjustment;
                }
                if (imgSize.Width > (scrnSize.Width + 12))
                {
                    statusText = "Image resolution is higher than monitor resolution!";
                    int adjustment = (imgSize.Width - (scrnSize.Width + 12)) / 2;
                    ccPreview.Left = -adjustment;
                }
                if(statusText != string.Empty)
                    MainForm.sInstance.SetStatusText(statusText);
                shownMessage = true;
            }
        }

        private void HiddenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            disposed = true;            
            CaptureCard.Stop();
        }
    }
}
