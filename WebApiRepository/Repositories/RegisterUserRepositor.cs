using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebApiRepository.Models;
using WebApiRepository.Contracts;
using WebApiRepository.Helpers;

namespace WebApiRepository.Repositories
{
    public class RegisterUserRepositor : IRegisterUser
    {
        private readonly DataContext _context;
        public RegisterUserRepositor(DataContext context)
        {
            _context = context;
        }

        public void Add(RegisterUserModel registeruser)
        {
            //_context.RegisterUser.Add(registeruser);
            //_context.SaveChanges();
        }

        public int GetLoggedUserID(RegisterUserModel registeruser)
        {
            //var usercount = (from User in _context.RegisterUser
            //                 where User.Username == registeruser.Username &&
            //                       User.Password == registeruser.Password
            //                 select User.UserID).FirstOrDefault();

            //return usercount;
            return 1;
        }

        public bool ValidateRegisteredUser(RegisterUserModel registeruser)
        {
            //var usercount = (from User in _context.RegisterUser
            //                 where User.Username == registeruser.Username &&
            //                 User.Password == registeruser.Password
            //                 select User).Count();
            //if (usercount > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }

        public bool ValidateUsername(RegisterUserModel registeruser)
        {
            //var usercount = (from User in _context.RegisterUser
            //                 where User.Username == registeruser.Username
            //                 select User).Count();
            //if (usercount > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }
    }
}
