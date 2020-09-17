using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using WalletService;
using Xamarin.Forms;


namespace storyboard
{
    public partial class MainForm : UIViewController
    {

        [Action("backtoMainFormcontroller:")]
        public void BacktoMainFormcontroller(UIStoryboardSegue segue)
        {
        }

        public MainForm(IntPtr handle) : base(handle)
        {
            
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            Forms.Init();
            decimal value = 0m;
            value = await WAction.ShowAsset();
            balancelabel.Text = Convert.ToString(value);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        //QR Scanner 呼び出しとsendinfoに画面遷移
        partial void QRscanButton_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("send", this);
            QRscanner.MainPage qr = new QRscanner.MainPage();
            qr.OnQR();   
        }
    }
}