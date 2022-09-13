using projectPSD.Models;
using projectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Handler
{
    public class TransactionHandler
    {
        public static List<payment> GetPayments()
        {
            return PaymentRepository.GetPayments();
        }

        public static void InsertToDB(String userId, String paymentId, String status, List<cart> carts, String address, bool assurance)
        {
            TransactionRepository.InsertToDB(userId, DateTime.Now, paymentId, status, carts, address, assurance);
        }

        public static List<transaction> GetUserTransactions(String userId)
        {
            return TransactionRepository.GetUserTransactions(userId);
        }

        public static List<transaction> GetWaitingTransactions()
        {
            return TransactionRepository.GetWaitingTransactions();
        }

        public static List<transaction> GetUnwaitingTransactions()
        {
            return TransactionRepository.GetUnwaitingTransactions();
        }

        public static void UpdateTransactionStatus(String id, String status)
        {
            TransactionRepository.UpdateTransactionStatus(id, status);
        }

        public static transaction GetTransaction(String transactionId)
        {
            return TransactionRepository.GetTransaction(transactionId);
        }

        public static List<transaction_details> GetTransaction_Details(String transactionId)
        {
            return TransactionRepository.GetTransaction_Details(transactionId);
        }
    }
}