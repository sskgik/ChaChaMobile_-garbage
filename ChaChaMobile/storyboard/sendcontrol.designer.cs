// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace storyboard
{
    [Register ("sendcontrol")]
    partial class sendcontrol
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField amount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField destinationpubkey { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton QRscan { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton send_bottun { get; set; }

        [Action ("QRscan_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void QRscan_TouchUpInside (UIKit.UIButton sender);

        [Action ("Send_bottun_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Send_bottun_TouchUpInsideAsync (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (amount != null) {
                amount.Dispose ();
                amount = null;
            }

            if (destinationpubkey != null) {
                destinationpubkey.Dispose ();
                destinationpubkey = null;
            }

            if (QRscan != null) {
                QRscan.Dispose ();
                QRscan = null;
            }

            if (send_bottun != null) {
                send_bottun.Dispose ();
                send_bottun = null;
            }
        }
    }
}