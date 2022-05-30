using System;
using System.Linq;
using MyBank.Data.Repository;
using System.Collections.Generic;

namespace MyBank.Data.Repository.User.Impl
{
    public class RegisterRepository : IRegisterRepository
    {
        private BankContext _context;

        public RegisterRepository(BankContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.User> GetUsers()
        {
            IEnumerable<Models.User> users = _context.User.ToList();
            return users;
        }

        public Models.User GetUser(string email)
        {
            Models.User userToReturn = _context.User.FirstOrDefault(user => user.Email == email);
            return userToReturn;
        }

        public int GetUserCount(string email)
        {
            int userCount = _context.User.Count(user => user.Email == email);
            return userCount;
        }

        public Models.User CreateUser(Models.User createdUser)
        {
            _context.User.Add(createdUser);
            _context.SaveChanges();
            return createdUser;
        }

        public void UpdateUser(Models.User updatedUser)
        {
            _context.User.Update(updatedUser);
            _context.SaveChanges();
            return;
        }

        public void DeleteUser(int UserID)
        {
            Models.User userToDelete = _context.User.FirstOrDefault(user => user.Id == UserID);
            if (userToDelete != null) _context.User.Remove(userToDelete);
            _context.SaveChanges();
            return;
        }
    }
}