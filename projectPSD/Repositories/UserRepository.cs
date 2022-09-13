using projectPSD.Factories;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Repositories
{
    public class UserRepository
    {
        static projectDBEntities db = DBSingleton.GetInstance();

        public static List<user> GetUsers()
        {
            return db.users.ToList();
        }

        public static String GetLastId()
        {
            user user = GetUsers().LastOrDefault();
            return user.Id;
        }

        public static String GenerateId()
        {
            String nextId = "";
            String lastId = GetLastId();
            if (lastId != null)
            {
                int lastNumber = Convert.ToInt32(lastId.Substring(2));
                nextId = String.Format("US{0:000}", lastNumber + 1);
            }
            else
            {
                nextId = "US001";
            }
            return nextId;
        }

        public static void InsertToDB(String name, String email, String password)
        {
            user user = UserFactory.create(GenerateId(), name, email, password);
            db.users.Add(user);
            db.SaveChanges();
        }

        public static user Authenticate(String email, String password)
        {
            return (from user in db.users where user.email.Equals(email) && user.password.Equals(password) select user).FirstOrDefault();
        }

        public static user GetUserById(String userId)
        {
            return (from user in db.users where user.Id == userId select user).FirstOrDefault();
        }
    }
}