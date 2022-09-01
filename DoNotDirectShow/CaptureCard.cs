using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace DoNotDirectShow
{
    public static class CaptureCard
    {
        static FilterInfoCollection filterInfoCollection;
        static VideoCaptureDevice captureDevice;
        static HiddenForm frmPreview;
        static Bitmap img; 

        private static void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            img = (Bitmap)eventArgs.Frame.Clone();
            frmPreview.UpdateImage(img);
        }

        public static void Create(ComboBox cBox)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fInfo in filterInfoCollection)
                cBox.Items.Add(fInfo.Name);
            cBox.SelectedIndex = 0;
            captureDevice = new VideoCaptureDevice();
        }

        public static void Start(ComboBox cBox)
        {
            frmPreview = new HiddenForm();
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cBox.SelectedIndex].MonikerString);
            captureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            captureDevice.Start();
            frmPreview.Show();
        }

        public static void ScreenShot()
        {
            if(img != null)
                img.Save(@"Screenshot.png");
        }

        public static void Stop()
        {
            if(frmPreview != null)
                frmPreview.Dispose();

            // With the capture card i have it sometimes freezes, unsure why and if this appies to other capture cards as well
            captureDevice.SignalToStop();
            captureDevice.WaitForStop();
        }
               

    }     
}
