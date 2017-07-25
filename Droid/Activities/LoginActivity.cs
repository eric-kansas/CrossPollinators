using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Android.Support.V4.Content;
using Android.Graphics;

namespace playground.Droid.UI
{
    [Activity(Label = "@string/login",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : BaseActivity
    {
        /// <summary>
        /// Specify the layout to inflace
        /// </summary>
        protected override int LayoutResource => Resource.Layout.activity_login;

        Button signInButton, notNowButton;
        LinearLayout signingInPanel;
        ProgressBar progressBar;
        LoginViewModel viewModel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Layout gets inflated here
            base.OnCreate(savedInstanceState);

            viewModel = new LoginViewModel();

            signInButton = FindViewById<Button>(Resource.Id.button_signin);
            notNowButton = FindViewById<Button>(Resource.Id.button_not_now);

            signInButton.Text = "Sign In";

            progressBar = FindViewById<ProgressBar>(Resource.Id.progressbar_signin);
            signingInPanel = FindViewById<LinearLayout>(Resource.Id.container_signin);

            progressBar.Indeterminate = false;
            signingInPanel.Visibility = ViewStates.Invisible;

            //Turn off back arrows
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);
        }

        protected override void OnStart()
        {
            base.OnStart();
            signInButton.Click += SignInButton_Click;
            notNowButton.Click += NotNowButton_Click;
        }

        protected override void OnStop()
        {
            base.OnStop();
            signInButton.Click -= SignInButton_Click;
            notNowButton.Click -= NotNowButton_Click;
        }

        void NotNowButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            StartActivity(intent);
            Finish();
        }

        async void SignInButton_Click(object sender, System.EventArgs e)
        {
            await viewModel.SignIn();

            if (Settings.IsLoggedIn)
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                StartActivity(intent);
                Finish();
            }
        }
    }
}

