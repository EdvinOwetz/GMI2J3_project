using LoginDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LoginDomain.Services.AuthenticationServices.IAuthenticationService;

namespace Login_service.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }
        event Action StateChanged;

        /// <summary>
        /// Registers a new account
        /// </summary>
        /// <param name="username">The Username</param>
        /// <param name="password">The password</param>
        /// <param name="confirmPassword">The password to see if it is the same</param>
        /// <param name="email">Accounts email address</param>
        /// <returns></returns>
        Task<RegistrationResult> Register(string username, string password, string confirmPassword, string email);
        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task Login(string username, string password);
        void Logout();
    }
}
