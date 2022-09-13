using projectPSD.Repositories;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectPSD.Handler;

namespace projectPSD.Controllers
{
    public class LoginController
    {
        public static String CheckPassword(String password)
        {
            String response = "";
            if (password.Length == 0) response = "password cannot be empty";
            return response;
        }
        public static String CheckEmail(String email)
        {
            String response = "";
            if (email.Length == 0) response = "email cannot be empty";
            return response;
        }

        public static String ValidateLogin(String email, String password)
        {
            String response = CheckEmail(email);
            if (response.Equals("")) response = CheckPassword(password);
            return response;
        }

        public static user DoLogin(String email, String password)
        {
            
            return UserHandler.DoLogin(email, password);
        }

        public static user GetUserById(String id)
        {
            return UserHandler.GetUserById(id);
        }
    }
}