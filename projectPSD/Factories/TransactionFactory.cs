using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Factories
{
    public class TransactionFactory
    {
        public static transaction create(String id, String user_id, DateTime transaction_date, String payment_id, String status, String address, bool assurance)
        {
            transaction trans = new transaction();
            trans.Id = id;
            trans.user_id = user_id;
            trans.transaction_date = transaction_date;
            trans.payment_id = payment_id;
            trans.status = status;
            trans.address = address;
            trans.assurance = assurance;
            return trans;
        }
        
        public static transaction_details createDetails(String transaction_id, String product_id, int quantity)
        {
            transaction_details transaction_Details = new transaction_details();
            transaction_Details.transaction_id = transaction_id;
            transaction_Details.product_id = product_id;
            transaction_Details.quantity = quantity;

            return transaction_Details;
        }
    }
}