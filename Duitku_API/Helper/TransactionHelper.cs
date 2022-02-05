using Binus.WS.Pattern.Entities;
using Duitku_API.Model;

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
    }
}
