using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Content.PM;

namespace playground.Droid.UI
{
    [Activity(Label = "Login",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignInActivity : BaseActivity
    {
        protected override int LayoutResource => Resource.Layout.activity_sign_in;

        LoginViewModel viewModel;
        Button signInButton, registerButton;
        EditText emailInput, passwordInput;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Layout gets inflated here
            base.OnCreate(savedInstanceState);

            viewModel = new LoginViewModel();

            signInButton = FindViewById<Button>(Resource.Id.button_signin);
            registerButton = FindViewById<Button>(Resource.Id.button_register);

            emailInput = FindViewById<EditText>(Resource.Id.input_email);
            passwordInput = FindViewById<EditText>(Resource.Id.input_password);

            // Turn on back arrows
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        protected override void OnStart()
        {
            base.OnStart();
            signInButton.Click += SignInButton_Click;
            registerButton.Click += RegisterButton_Click;
        }

        protected override void OnStop()
        {
            base.OnStop();
            signInButton.Click -= SignInButton_Click;
            registerButton.Click -= RegisterButton_Click;
        }

        async void SignInButton_Click(object sender, System.EventArgs e)
        {
            await viewModel.SignIn(emailInput.Text, passwordInput.Text);

            if (Settings.IsLoggedIn)
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
                StartActivity(intent);
                FinishAffinity();
            }
        }

        void RegisterButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(Application.Context, typeof(RegisterActivity));
            StartActivity(intent);
        }
    }
}

