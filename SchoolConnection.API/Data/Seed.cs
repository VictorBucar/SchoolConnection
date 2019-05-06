using System.Collections.Generic;
using Newtonsoft.Json;
using SchoolConnection.API.Models;

namespace SchoolConnection.API.Data
{
    public class Seed
    {
        private DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }
        public void SeedUsers(){
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(out passwordHash, out passwordSalt, "password");

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Name = user.Name.ToLower();

                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }

        private void CreatePasswordHash(out byte[] passwordHash, out byte[] passwordSalt, string password)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}