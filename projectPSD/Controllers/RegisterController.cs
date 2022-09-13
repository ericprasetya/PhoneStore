using projectPSD.Handler;
using projectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Controllers
{
    public class RegisterController
    {

        public static String CheckEmail(String email)
        {
            String response = "";
            if (email.Length == 0)
            {
                response = "email cannot be empty";
            }
            if (email.EndsWith(".com") == false && email.EndsWith(".co.id") ==false){
                response = "email must be end with .com or .co.id";
            }
            return response;
        }

        public static String CheckName(String name)
        {
            String response = "";
            if (name.Length == 0) response = "name cannot be empty";
            return response;
        }

        public static String CheckPassword(String password)
        {
            String response = "";
            if (password.Length == 0)
            {
                response = "password cannot be empty";
            } 
            if(password.All(char.IsLetterOrDigit) == false)
            {
                response = "password must contains alphanumeric only";
            }
            return response;
        }


        public static String DoRegister(String name, String email, String password)
        {
            String response = CheckName(name);
            if (response.Equals("")) response = CheckEmail(email);
            if (response.Equals("")) response = CheckPassword(password);

            if (response.Equals(""))
            {
                UserHandler.DoRegister(name, email, password);
            }
            return response;
        }
    }
}