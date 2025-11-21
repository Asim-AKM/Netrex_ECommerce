using Application_Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.Implementation
{
    internal class PasswordEncriptor : IPasswordEncriptor
    {
        public Task CreateHashAndSalt(string password,out byte[] salt, out byte[] hash)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Task.CompletedTask;
        }

        public Task<bool> VerifyPassword(string password, byte[] storesalt, byte[] storeHash)
        {
            using var hmac = new HMACSHA512(storesalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Task.FromResult(computedHash.SequenceEqual(storeHash));
        }
    }
}
