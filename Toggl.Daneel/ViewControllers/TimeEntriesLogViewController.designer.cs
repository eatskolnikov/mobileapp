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

namespace Toggl.Daneel.ViewControllers
{
    [Register ("TimeEntriesLogViewController")]
    partial class TimeEntriesLogViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView CenterImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EmptyStateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EmptyStateTextLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EmptyStateTitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView EmptyStateView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TimeEntries { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CenterImageView != null) {
                CenterImageView.Dispose ();
                CenterImageView = null;
            }

            if (EmptyStateButton != null) {
                EmptyStateButton.Dispose ();
                EmptyStateButton = null;
            }

            if (EmptyStateTextLabel != null) {
                EmptyStateTextLabel.Dispose ();
                EmptyStateTextLabel = null;
            }

            if (EmptyStateTitleLabel != null) {
                EmptyStateTitleLabel.Dispose ();
                EmptyStateTitleLabel = null;
            }

            if (EmptyStateView != null) {
                EmptyStateView.Dispose ();
                EmptyStateView = null;
            }

            if (TimeEntries != null) {
                TimeEntries.Dispose ();
                TimeEntries = null;
            }
        }
    }
}