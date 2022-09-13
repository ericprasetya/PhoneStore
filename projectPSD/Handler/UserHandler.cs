using projectPSD.Models;
using projectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Handler
{
    public class UserHandler
    {
        public static user GetUserById(String id)
        {
            return UserRepository.GetUserById(id);
        }

        public static user DoLogin(String email, String password)
        {
            return UserRepository.Authenticate(email, password);
        }

        public static void DoRegister(String name, String email, String password)
        {
            UserRepository.InsertToDB(name, email, password);
        }
    }
}