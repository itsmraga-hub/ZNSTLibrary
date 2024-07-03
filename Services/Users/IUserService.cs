﻿using ZNSTLibrary.Authentication;
using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Data.Services.Users
{
    public interface IUserService
    {
        Task<UserSession> CreateUserAsync(User user);
        Task<UserSession> AuthenticateUser(string email, string password);

        Task<User> GetUser(string id);

        Task MakeAdmin(string id);

        Task MakeUser(string id);

        Task MakeStaff(string id);

        Task<List<User>> GetUsers(string role);
    }
}
