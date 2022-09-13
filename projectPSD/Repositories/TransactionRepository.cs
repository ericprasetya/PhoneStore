using projectPSD.Factories;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Repositories
{
    public class TransactionRepository
    {
        private static projectDBEntities db = DBSingleton.GetInstance();

        public static List<transaction> GetTransactions()
        {
            return db.transactions.ToList();
        }

        public static List<transaction> GetWaitingTransactions()
        {
            return db.transactions.Where(x => x.status == "waiting approval").ToList();
        }

        public static List<transaction> GetUnwaitingTransactions()
        {
            return db.transactions.Where(x => x.status != "waiting approval").ToList();
        }

        public static void UpdateTransactionStatus(String id, String status)
        {
            transaction transaction = db.transactions.Find(id);
            transaction.status = status;
            db.SaveChanges();
        }
        
        public static List<transaction_details> GetTransaction_Details()
        {
            return db.transaction_details.ToList();
        }

        public static String GetLastId()
        {
            transaction transaction = GetTransactions().LastOrDefault();
            return transaction.Id;
        }

        public static String GenerateId()
        {
            String nextId = "";
            String lastId = GetLastId();
            if (lastId != null)
            {
                int lastNumber = Convert.ToInt32(lastId.Substring(2));
                nextId = String.Format("TR{0:000}", lastNumber + 1);
            }
            else
            {
                nextId = "TR001";
            }
            return nextId;
        }

        public static void InsertToDB(String userId, DateTime transactionDate, String paymentId, String status, List<cart> carts, String address, bool assurance)
        {
            String transactionId = GenerateId();
            transaction transaction = TransactionFactory.create(transactionId, userId, transactionDate, paymentId, status, address, assurance);
            db.transactions.Add(transaction);
            foreach(cart cart in carts)
            {
                transaction_details transactionDetails = TransactionFactory.createDetails(transactionId, cart.product_id, cart.quantity);
                db.transaction_details.Add(transactionDetails);
            }
            db.SaveChanges();
        }

        public static List<transaction> GetUserTransactions(String userId)
        {
            return db.transactions.Where(tr => tr.user_id == userId).ToList();
        }

        public static transaction GetTransaction(String transactionId)
        {
            return db.transactions.Find(transactionId);
        }

        public static List<transaction_details> GetTransaction_Details(String transactionId)
        {
            return db.transaction_details.Where(tr => tr.transaction_id == transactionId).ToList();
        }
    }
}