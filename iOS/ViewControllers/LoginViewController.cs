using System;
using UIKit;

namespace playground.iOS
{
    public partial class LoginViewController : UIViewController
    {
        public RegisterViewModel ViewModel;

        public LoginViewController(IntPtr handle) : base(handle)
        {
            ViewModel = new RegisterViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = ViewModel.Title;
        }

        partial void NotNowButton_TouchUpInside(UIButton sender) => NavigateToTabbed();

        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            if (Settings.IsLoggedIn)
                NavigateToTabbed();
        }

        void NavigateToTabbed()
        {
            InvokeOnMainThread(() =>
                {
                    var app = (AppDelegate)UIApplication.SharedApplication.Delegate;
                    app.Window.RootViewController = UIStoryboard.FromName("Main", null)
                                                     .InstantiateViewController("tabViewController")
                                                     as UITabBarController;
                });
        }
    }
}
