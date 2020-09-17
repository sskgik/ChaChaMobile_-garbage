using System;
using UIKit;
using System.Threading.Tasks;
using Miyabi.Cryptography;
using Miyabi.ClientSdk;
using Miyabi.Common.Models;
using WalletService;

namespace storyboard
{
    public partial class sendcontrol : UIViewController
    {
        private string qrvalue = string.Empty;
        public string QRresult { get; set; }

        public sendcontrol(IntPtr handle) : base(handle)
        {
        }

        //呼び出し時にテキストにQRresultの値を格納
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            destinationpubkey.Text = this.QRresult;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void QRscan_TouchUpInside(UIButton sender)
        {
            QRscanner.MainPage qr = new QRscanner.MainPage();
            qr.OnQR();
        }

        async partial void Send_bottun_TouchUpInsideAsync(UIButton sender)
        {
            var client = WAction.SetClient();
            var _generalClient = new GeneralApi(client);

            //mypublickey
            string text1 = "0338f9e2e7ad512fe039adaa509f7b555fb88719144945bd94f58887d8d54fed78";
            Address mypublickey = this.Inputjudgement(text1);
            if (mypublickey == null)
            {
                return;
            }
            // Get destinationpublickey string
            string text2 = this.destinationpubkey.Text;
            Address opponetpublickey = this.Inputjudgement(text2);
            if (opponetpublickey == null)
            {
                return;
            }

            // get textBox3 string
            string text3 = this.amount.Text;
            decimal amount = this.Inputnumjudgement(text3);
            if (amount == 0m)
            {
                return;
            }

            // throw amount to form1
            //this.Showtransaction(amount);

            // send coin BroadCast Miyabi
            WAction send = new WAction();
            (string transaction, string result) = await send.Send(mypublickey, opponetpublickey, amount);

            //Transaction result
            //Create Alert
            var okAlertController = UIAlertController.Create("Result:\t" + result, "tx:\t" + transaction, UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("confirm", UIAlertActionStyle.Default, null));

            // Present Alert
            PresentViewController(okAlertController, true, null);

        }

        /// <summary>
        /// Check if the entered information can be converted about publickey.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Inputaddress</returns>
        private Address Inputjudgement(string text)
        {
            Address inputaddress;
            try
            {
                var value = PublicKey.Parse(text);
                inputaddress = new PublicKeyAddress(value);
            }
            catch (Exception e)
            {
                //Create Alert
                var okAlertController = UIAlertController.Create("警告", "入力したパブリックキーが誤っています再入力してください", UIAlertControllerStyle.Alert);

                //Add Action
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(okAlertController, true, null);

                inputaddress = null;
            }

            return inputaddress;
        }

        /// <summary>
        /// Check if the entered information can be converted about amount.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>inputamount</returns>
        private decimal Inputnumjudgement(string text)
        {
            decimal inputamount = 0m;

            try
            {
                inputamount = Convert.ToDecimal(text);
            }
            catch (Exception)
            {
                //Create Alert
                var okAlertController = UIAlertController.Create("警告", "入力したamountが数字ではありません再入力してください", UIAlertControllerStyle.Alert);

                //Add Action
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(okAlertController, true, null);
                inputamount = 0m;
            }

            return inputamount;
        }
    }
}

