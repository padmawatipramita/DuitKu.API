using Binus.WS.Pattern.Entities;
using Duitku_API.Model;
using Duitku_API.Output;

namespace Duitku_API.Helper
{
    public class UserHelper
    {
        public static List<UserDetail> GetAllUser()
        {
            var returnValue = new List<UserDetail>();
        

            try
            {
   
                foreach (var dataUser in EntityHelper.Get<msUser>().ToList())
                {
                    var income = EntityHelper.Get<trTransaction>().Where(x => x.UserID == dataUser.UserID && x.TransactionType == "Income").Select(x=> x.Balance).ToList().Sum();
                    var expense = EntityHelper.Get<trTransaction>().Where(x => x.UserID == dataUser.UserID && x.TransactionType == "Expense").Select(x => x.Balance).ToList().Sum();
                    UserDetail newUser = new UserDetail();

                    newUser.UserEmail = dataUser.UserEmail;
                    newUser.UserName = dataUser.UserName;
                    newUser.UserBalance = dataUser.UserBalance;
                    newUser.UserFinalBalance = dataUser.UserBalance + (income - expense);
                 

                    returnValue.Add(newUser);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnValue;
        }

        public static int AddNewUser(UserDetail data)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return 1;
        }

        public static int ChangePersonalData(msUser data)
        {
            try
            {
                // update personal data
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return 1;
        }
    }
}
