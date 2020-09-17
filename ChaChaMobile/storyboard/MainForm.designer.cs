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
    [Register ("MainForm")]
    partial class MainForm
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel balancelabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton QRscanButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton recievebutton { get; set; }

        [Action ("QRscanButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void QRscanButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (balancelabel != null) {
                balancelabel.Dispose ();
                balancelabel = null;
            }

            if (QRscanButton != null) {
                QRscanButton.Dispose ();
                QRscanButton = null;
            }

            if (recievebutton != null) {
                recievebutton.Dispose ();
                recievebutton = null;
            }
        }
    }
}