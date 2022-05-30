using System.Collections.Generic;

namespace MyBank.Data.Repository.User
{
    public interface IRegisterRepository
    {
        IEnumerable<Models.User> GetUsers();

        Models.User GetUser(string email);
        
        public int GetUserCount(string email);

        Models.User CreateUser(Models.User createdUser);

        void UpdateUser(Models.User updatedUser);

        void DeleteUser(int UserID);
    }
}
