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
    [Activity(Label = "Login",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignInActivity : BaseActivity
    {
        /// <summary>
        /// Specify the layout to inflace
        /// </summary>
        protected override int LayoutResource => Resource.Layout.activity_sign_in;

        Button signInButton, registerButton;
        EditText emailInput, passwordInput;
        LinearLayout signingInPanel;
        ProgressBar progressBar;
        LoginViewModel viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Layout gets inflated here
            base.OnCreate(savedInstanceState);

            viewModel = new LoginViewModel();

            signInButton = FindViewById<Button>(Resource.Id.button_signin);
            registerButton = FindViewById<Button>(Resource.Id.button_register);

            emailInput = FindViewById<EditText>(Resource.Id.input_email);
            passwordInput = FindViewById<EditText>(Resource.Id.input_password);

            //progressBar = FindViewById<ProgressBar>(Resource.Id.progressbar_signin);
            //signingInPanel = FindViewById<LinearLayout>(Resource.Id.container_signin);

            //progressBar.Indeterminate = false;
            //signingInPanel.Visibility = ViewStates.Invisible;

            //Turn off back arrows
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);
        }

        protected override void OnStart()
        {
            base.OnStart();
            signInButton.Click += SignInButton_Click;
            registerButton.Click += CancelButton_Click;
        }

        protected override void OnStop()
        {
            base.OnStop();
            signInButton.Click -= SignInButton_Click;
            registerButton.Click -= CancelButton_Click;
        }

        async void SignInButton_Click(object sender, System.EventArgs e)
        {
            await viewModel.SignIn(emailInput.Text, passwordInput.Text);

            if (Settings.IsLoggedIn)
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                StartActivity(intent);
                Finish();
            }
        }

        void CancelButton_Click(object sender, System.EventArgs e)
        {
            Finish();
        }
    }
}

