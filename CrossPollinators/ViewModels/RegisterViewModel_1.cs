using System.Threading.Tasks;
using System.Windows.Input;
using System;

namespace playground
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            Title = "Register";
        }

        string message = string.Empty;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public ICommand NotNowCommand { get; }
        public ICommand SignInCommand { get; }

        public async Task Register(String email, String password)
        {
            try
            {
                IsBusy = true;
                Message = "Registering...";

                // Log the user in
                await TryRegisterAsync(email, password);
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;
            }
        }

        public async Task<bool> TryRegisterAsync(String email, String password)
        {
            String response = "";
            try
            {
                response = await DataStore.Register(email, password);
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
                return await TryLoginAsync(email, password);
            }
            return false;
        }


        private async Task<bool> TryLoginAsync(String email, String password)
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
