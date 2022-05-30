using System;
using System.Linq;
namespace MyBank.Data.Repository.Login.Impl
{
    public class LoginRepository : ILoginRepository
    {
        private readonly BankContext _context;
        public LoginRepository(BankContext context)
        {
            _context = context;
        }

        public bool GetLogin(string email, string password, bool check)
        {
            if(check == true)
            {
                int loginUserCount = _context.Login.Count(login => login.Email == email && login.Password == password);
                if (loginUserCount > 0) return true;
            }

            return false;
        }

        public Models.Login GetLogin(string email, string password)
        {
            Models.Login loginUser = _context.Login.FirstOrDefault(login => login.Email == email && login.Password == password);
            return loginUser;
        }

        public Models.Login Createlogin(Models.Login login)
        {
            _context.Login.Add(login);
            _context.SaveChanges();
            return login;
        }

        public void UpdateLogin(Models.Login login)
        {
            _context.Login.Update(login);
            _context.SaveChanges();
        }
    }
}
