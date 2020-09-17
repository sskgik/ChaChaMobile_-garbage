using Foundation;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using storyboard;

namespace ChaChaMobile
{
    public partial class QRcontrol : UIViewController
    {
        public string qrresult = string.Empty;
        public QRcontrol(IntPtr handle) : base(handle)
        {
        }

        //呼び出し時のQRscannerの呼び出しと値の遷移まで
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            Forms.Init();
            var qr = new QRscanner.QRScanPage();
            qrresult = qr.Handle_OnScanResult();
            if(qrresult != string.Empty)
            {

                this.PerformSegue("backsend", this);
            }
            else
            {
                QRscanner.MainPage qrretry = new QRscanner.MainPage();
                qrretry.OnQR();
            }

            var viewController = qr.CreateViewController();
            this.AddChildViewController(viewController);
            this.View.Add(viewController.View);
            viewController.DidMoveToParentViewController(this);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //sendcontrolに値の遷移
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if (String.Equals(segue.Identifier, "backsend"))
            {
                var vc = segue.DestinationViewController as sendcontrol;
                vc.QRresult = qrresult;
            }    
        }

    }
}