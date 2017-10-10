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

        public async Task SignIn()
        {
            try
            {
                IsBusy = true;
                Message = "Signing In...";
                Console.WriteLine("SignIn: " + Message);


                // Log the user in
                await TryLoginAsync();
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;
            }
        }


        public static async Task<bool> TryLoginAsync()
        {
            Settings.UserId = "something";
            return true;
        }
    }
}
