using System;
using System.Collections.Generic;
using System.Text;
using WebApiRepository.Models;

namespace WebApiRepository.Contracts
{
    public interface IUser
    {
        UserModel Authenticate(string username, string password);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel Create(UserModel user, string password);
        void Update(UserModel user, string password = null);
        void Delete(int id);
    }
}
