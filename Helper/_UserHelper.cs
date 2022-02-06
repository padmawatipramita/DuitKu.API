using Binus.WS.Pattern.Entities;
using DuitKu.API.Model;
using DuitKu.API.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuitKu.API.Helper
{
    public class _UserHelper
    {
        public static List<UserDetail> GetAllUser()
        {
            var returnValue = new List<UserDetail>();

            try
            {
                // get all user
                foreach (var dataUser in EntityHelper.Get<_UserModel>().ToList())
                {
                    var income = EntityHelper.Get<_TransactionModel>().Where(x => 
                        x.UserID == dataUser.UserID && x.TransactionType == "Income").Select(x => 
                        x.Balance).ToList().Sum();

                    var expense = EntityHelper.Get<_TransactionModel>().Where(x => 
                        x.UserID == dataUser.UserID && x.TransactionType == "Expense").Select(x => 
                        x.Balance).ToList().Sum();

                    UserDetail newUser = new UserDetail();

                    newUser.UserEmail = dataUser.UserEmail;
                    newUser.UserName = dataUser.UserName;
                    newUser.UserBalance = (int)dataUser.UserBalance;
                    newUser.UserFinalBalance = (int)dataUser.UserBalance + (income - expense);

                    returnValue.Add(newUser);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnValue;
        }

        public static int AddNewUser(_UserModel data)
        {
            try
            {
                // add new user
                EntityHelper.Add(new _UserModel()
                {
                    UserName = data.UserName,
                    UserEmail = data.UserEmail,
                    UserPassword = data.UserPassword,
                    UserBalance = data.UserBalance,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return 1;
        }

        public static int ChangePersonalData(_UserModel data)
        {
            var returnValue = new _UserModel();
            var userModel = EntityHelper.Get<_UserModel>().ToList();

            try
            {
                // update personal data
                returnValue = (
                    from um in userModel.Where(dataRow => dataRow.UserID == data.UserID)
                    select new _UserModel()
                    {
                        UserID = um.UserID,
                        UserName = um.UserName,
                        UserEmail = um.UserEmail,
                        UserPassword = um.UserPassword,
                        UserBalance = um.UserBalance,
                    }).FirstOrDefault();

                if (returnValue == null)
                {
                    throw new Exception("User ID not found!");
                }

                EntityHelper.Update(new _UserModel()
                {
                    UserID = data.UserID,
                    UserName = data.UserName ?? returnValue.UserName,
                    UserEmail = data.UserEmail ?? returnValue.UserEmail,
                    UserPassword = data.UserPassword ?? returnValue.UserPassword,
                    UserBalance = data.UserBalance ?? returnValue.UserBalance,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return 1;
        }

        /*
        Modified by Ariel Sefrian
        Date: Minggu, 06/02/2022 - 22:41 WIB
        Purpose: fix the getSpecificUser codes in _UserHelper
        */

        public static List<SpecificUserDetail> GetSpecificUser(int? UserIDParam)
        {
            var returnValue = new List<SpecificUserDetail>();
            var userModel = EntityHelper.Get<_UserModel>().ToList();
            var transactionModel = EntityHelper.Get<_TransactionModel>().ToList();

            try
            {
                // get specific user
                var income = EntityHelper.Get<_TransactionModel>().Where(
                    x => x.UserID == UserIDParam && x.TransactionType == "Income").Select(
                    x => x.Balance).ToList().Sum();

                var expense = EntityHelper.Get<_TransactionModel>().Where(
                    x => x.UserID == UserIDParam && x.TransactionType == "Expense").Select(
                    x => x.Balance).ToList().Sum();

                returnValue = (
                   from um in userModel.Where(dataRow => dataRow.UserID == UserIDParam)
                   select new SpecificUserDetail
                   {
                       UserName = um.UserName,
                       UserEmail = um.UserEmail,
                       UserBalance = (int)um.UserBalance,
                       UserFinalBalance = (int)um.UserBalance + (income - expense),
                   }).ToList();

                if (returnValue.Capacity.Equals(0))
                {
                    throw new Exception("Account not found!");
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