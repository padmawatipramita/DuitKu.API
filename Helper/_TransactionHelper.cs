using Binus.WS.Pattern.Entities;
using DuitKu.API.Model;
using DuitKu.API.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuitKu.API.Helper
{
    public class _TransactionHelper
    {
        public static int AddNewTransaction(_TransactionModel data)
        {
            try
            {
                // add new transactions
                _TransactionModel newData = new _TransactionModel();

                newData.Balance = data.Balance;
                newData.Date = data.Date;
                newData.Notes = data.Notes;
                newData.UserID = data.UserID;
                newData.TransactionType = data.TransactionType;
                EntityHelper.Add < _TransactionModel>(newData);
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
                // get all transactions
                var Transaction = EntityHelper.Get<_TransactionModel>().ToList();
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