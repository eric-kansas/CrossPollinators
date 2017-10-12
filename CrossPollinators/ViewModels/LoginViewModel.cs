using System.Threading.Tasks;
using System.Windows.Input;
using System;

namespace playground
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = "Login";
        }

        string message = string.Empty;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public ICommand NotNowCommand { get; }
        public ICommand SignInCommand { get; }

        public async Task SignIn(String email, String password)
        {
            try
            {
                IsBusy = true;
                Message = "Signing In...";

                // Log the user in
                await TryLoginAsync(email, password);
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;
            }
        }

        public async Task<bool> TryLoginAsync(String email, String password)
        {
            String response = "";
            try
            {
                response = await DataStore.Login(email, password);
            }
            catch (Exception ex)
            {
                // MessageDialog.SendMessage("Unable to load items.", "Error");
            }
            finally
            {
                IsBusy = false;
            }

            Console.WriteLine("reponse: " + response);

            if (response == "Success")
            {
                Settings.UserId = "something";
                return true;
            }
            return false;
        }
    }
}
