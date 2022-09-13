using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Repositories
{
    public class DBSingleton
    {
        private static projectDBEntities db = null;
        private DBSingleton()
        {

        }

        public static projectDBEntities GetInstance()
        {
            if(db == null)
            {
                db = new projectDBEntities();
            }

            return db;
        }
    }
}