namespace BygSpy.Services.Login
{
  
        public interface ILoginService
        {
            event Action<bool> OnLoginStateChanged;
            bool IsLoggedIn { get; }
            void Login(string email, string password);
        }
    
}
