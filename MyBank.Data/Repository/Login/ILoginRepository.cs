using System;
using MyBank.Models;
using System.Collections.Generic;

namespace MyBank.Data.Repository.Login
{
    public interface ILoginRepository
    {
        bool GetLogin(string email, string password, bool check);

        Models.Login GetLogin(string email, string password);

        Models.Login Createlogin(Models.Login login);

        void UpdateLogin(Models.Login login);
    }
}
