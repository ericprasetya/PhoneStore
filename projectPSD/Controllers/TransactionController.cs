using projectPSD.Handler;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Controllers
{
    public class TransactionController
    {
        public static List<payment> GetPayments()
        {
            return TransactionHandler.GetPayments();
        }

        public static List<transaction> GetUserTransactions(String userId)
        {
            return TransactionHandler.GetUserTransactions(userId);
        }

        public static List<transaction> GetWaitingTransactions()
        {
            return TransactionHandler.GetWaitingTransactions();
        }

        public static List<transaction> GetUnwaitingTransactions()
        {
            return TransactionHandler.GetUnwaitingTransactions();
        }

        private static bool CheckStatus(String status)
        {
            if(status.Equals("waiting approval"))
            {
                return true;
            }else if (status.Equals("declined"))
            {
                return true;
            }else if(status.Equals("on going"))
            {
                return true;
            }
            return false;
        }

        public static bool UpdateTransactionStatus(String id, String status)
        {
            if (CheckStatus(status))
            {
                TransactionHandler.UpdateTransactionStatus(id, status);
                return true;
            }
            return false;
        }

        public static transaction GetTransaction(String transactionId)
        {
            return TransactionHandler.GetTransaction(transactionId);
        }

        public static List<transaction_details> GetTransaction_Details(String transactionId)
        {
            return TransactionHandler.GetTransaction_Details(transactionId);
        }
    }
}