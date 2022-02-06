using Binus.WS.Pattern.Entities;
using Duitku_API.Model;
using Duitku_API.Output;

namespace Duitku_API.Helper
{
    public class TransactionHelper
    {
        public static int AddNewTransaction(trTransaction data)
        {
            try
            {
                    // add transaksi baru
                    trTransaction newData = new trTransaction();

                    newData.Balance = data.Balance;
                    newData.Date = data.Date;
                    newData.Notes = data.Notes;
                    newData.UserID = data.UserID;
                    newData.TransactionType = data.TransactionType;
                    EntityHelper.Add<trTransaction>(newData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return 1;
        }
        public static List<Transaction> GetAllTransaction()
        {
            var returnValue = new List<Transaction>();
            try
            {
                var Transaction = EntityHelper.Get<trTransaction>().ToList();
                foreach (var dataTransaction in Transaction)
                {
                    Transaction newTrans = new Transaction();

                    newTrans.Date = dataTransaction.Date;
                    newTrans.Balance = dataTransaction.Balance;
                    newTrans.TransactionType = dataTransaction.TransactionType;
                    newTrans.Notes = dataTransaction.Notes;

                    
                    returnValue.Add(newTrans); // Mendapatkan semua data
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnValue;
        }


    }
}
