using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Repositories
{
    public class PaymentRepository
    {
        private static projectDBEntities db = DBSingleton.GetInstance();

        public static List<payment> GetPayments()
        {
            return db.payments.ToList();
        }

    }
}