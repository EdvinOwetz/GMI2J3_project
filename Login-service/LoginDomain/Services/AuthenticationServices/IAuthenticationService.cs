using LoginDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDomain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        public enum RegistrationResult
        {
            Success,
            PasswordsDoNotMatch,
            EmailAlreadyExists,
            UsernameAlreadyExists,
            InvalidEmailAddress
        }
        /// <summary>
        /// Register a new account.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task<Account> Login(string username, string password);
    }
}
