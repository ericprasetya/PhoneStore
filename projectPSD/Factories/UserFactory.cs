using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Factories
{
    public class UserFactory
    {
        public static user create(String id, String name, String email, String password)
        {
            user user = new user();
            user.Id = id;
            user.name = name;
            user.email = email;
            user.password = password;

            return user;
        }
    }
}