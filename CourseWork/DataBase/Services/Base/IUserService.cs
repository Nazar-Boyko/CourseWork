using CourseWork.Account;
using CourseWork.DataBase.Enteties;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DataBase.Services.Base
{
    public interface IUserService
    {
        void AddUser(User user);
        List<User> ReadUser();

        void UpdateUserInDB(User user);

        List<Purchase> GetPurchaseHistory(User user);
    }
}
