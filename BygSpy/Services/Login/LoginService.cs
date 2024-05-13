namespace BygSpy.Services.Login
{
    public class LoginService: ILoginService
    {
        
            public event Action<bool> OnLoginStateChanged;
            public bool IsLoggedIn { get; private set; }

            public void Login(string email, string password)
            {
                // Your login logic here
                // For simplicity, let's assume login is successful if email and password are not empty
                bool loginSuccessful = !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password);

                if (loginSuccessful)
                {
                    IsLoggedIn = true;
                    OnLoginStateChanged?.Invoke(IsLoggedIn);
                }
            }
        
    }
}
