using ZNSTLibrary.Authentication;
using ZNSTLibrary.Data.Models;
using ZNSTLibrary.Data.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using ZNSTLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace ZNSTLibrary.Data.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ZNSTLibraryContext _context;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly ILogger<UserService> _logger;

        public UserService(ZNSTLibraryContext context, IPasswordHasher<IdentityUser> passwordHasher, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
            _passwordHasher = passwordHasher;
        }  

        public Task<UserSession> CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var hashedPassword = _passwordHasher.HashPassword(user, user.PasswordHash!);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.Id = Guid.NewGuid().ToString();
            user.PasswordHash = hashedPassword;
            _context.Users.Add(user);
            _context.SaveChanges();
            var userSession = new UserSession
            {
                Id = user.Id,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Username = user.UserName!,
                IsAuthenticated = true,
                Role = user.Role
            };
            return Task.FromResult(userSession);
        }

        public Task<UserSession> AuthenticateUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return Task.FromResult(new UserSession());
                // throw new InvalidOperationException("User not found.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Task.FromResult(new UserSession());
            }
            var userSession = new UserSession
            {
                Id = user.Id,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Username = user.UserName!,
                IsAuthenticated = true,
                Role = user.Role
            };

            return Task.FromResult(userSession);
        }

        public Task<User> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsers()
        {
            if (_context.Users == null)
            {
                return new List<User>();
            }
            return await _context.Users.Where(_ => _.Role == "Member").ToListAsync();
        }

        /*                public Task<UserSession> CreateUserAsync(User user)
                        {
                            Console.WriteLine("Sending email");
                            string to = "itsmraga@gmail.com"; //To address    
                            string from = "ragawilliam570@gmail.com"; //From address    
                            MailMessage message = new MailMessage(from, to);

                            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
                            message.Subject = "Sending Email Using Asp.Net & C#";
                            message.Body = mailbody;
                            message.BodyEncoding = Encoding.UTF8;
                            message.IsBodyHtml = true;
                            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                            NetworkCredential basicCredential1 = new
                            NetworkCredential("ragawilliam570", "fkgr xybj jogc hicl");
                            client.EnableSsl = true;
                            client.UseDefaultCredentials = false;
                            client.Credentials = basicCredential1;
                            try
                            {
                                client.Send(message);
                            }

                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            throw new NotImplementedException();
                        }*/
    }
}
