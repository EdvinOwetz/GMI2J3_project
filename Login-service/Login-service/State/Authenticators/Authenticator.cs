using LoginDomain.Models;
using LoginDomain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_service.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private Account _currentAccount;
        public Account CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            private set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }
        /// <summary>
        /// We have a current user and are logged in
        /// </summary>
        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        /// <summary>
        /// A bool that has an async method that logs us in
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task Login(string username, string password)
        {
            CurrentAccount = await _authenticationService.Login(username, password);
        }
        /// <summary>
        /// Sets the user to null which means that the current account is logged out
        /// </summary>
        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<IAuthenticationService.RegistrationResult> Register(string username, string password, string confirmPassword, string email)
        {
            return await _authenticationService.Register(username, password, confirmPassword, email);
        }
    }
}
