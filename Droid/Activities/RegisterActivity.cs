using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Content.PM;

namespace playground.Droid.UI
{
    [Activity(Label = "Register",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class RegisterActivity : BaseActivity
    {
        protected override int LayoutResource => Resource.Layout.activity_register;

        Button registerButton;
        EditText emailInput, passwordInput;
        RegisterViewModel viewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Layout gets inflated here
            base.OnCreate(savedInstanceState);

            viewModel = new RegisterViewModel();

            registerButton = FindViewById<Button>(Resource.Id.button_register);

            emailInput = FindViewById<EditText>(Resource.Id.register_input_email);
            passwordInput = FindViewById<EditText>(Resource.Id.register_input_password);

            // Turn on back arrows
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        protected override void OnStart()
        {
            base.OnStart();
            registerButton.Click += RegisterButton_Click;
        }

        protected override void OnStop()
        {
            base.OnStop();
            registerButton.Click -= RegisterButton_Click;
        }

        async void RegisterButton_Click(object sender, System.EventArgs e)
        {
            
            await viewModel.Register(emailInput.Text, passwordInput.Text);

            if (Settings.IsLoggedIn)
            {
                var intent = new Intent(Application.Context, typeof(MainActivity));
                intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
                StartActivity(intent);
                FinishAffinity();
            } else {
                // handle error
            }
        }
    }
}

