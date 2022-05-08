using LoginDomain.Exceptions;
using LoginDomain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LoginDomain.Services.AuthenticationServices.IAuthenticationService;

namespace LoginDomain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountDataService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountDataService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _accountService.GetByUserName(username);

            if (storedAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }
            return storedAccount;
        }
        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword, string email)
        {
            RegistrationResult result = RegistrationResult.Success;
            //checks if passwords are not equal then throwing exception
            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            Account emailAccount = await _accountService.GetByEmail(email);

            //Checks if the email already exists
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }
            if (ValidEmailAddress(email) == false)
            {
                result = RegistrationResult.InvalidEmailAddress;
            }

            Account usernameAccount = await _accountService.GetByUserName(username);
            //Checks if username already exists
            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                //hashes password
                string hashedPassword = _passwordHasher.HashPassword(password);

                //property of the user
                Account account = new Account()
                {
                    Email = email,
                    UserName = username,
                    PasswordHash = hashedPassword,
                    DateJoined = DateTime.Now
                };

                await _accountService.SavePersonAsync(account);
            }
            return result;
        }
        private bool ValidEmailAddress(string email)
        {
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {

                return false;
            }

        }
    }

}
