using System;
using System.Collections.Generic;
using System.Text;
using WebApiRepository.Models;

namespace WebApiRepository.Contracts
{
    public interface IRegisterUser
    {
        void Add(RegisterUserModel registeruser);
        bool ValidateRegisteredUser(RegisterUserModel registeruser);
        bool ValidateUsername(RegisterUserModel registeruser);
        int GetLoggedUserID(RegisterUserModel registeruser);
    }
}
