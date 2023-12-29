using CourseWork.Account;
using CourseWork.Command;
using CourseWork.DataBase.Enteties;
using CourseWork.DataBase.Repositories.Base;
using CourseWork.DataBase.Repositories;
using CourseWork.DataBase.Services.Base;
using System.Data;
using System.Net;
using CourseWork.Models;

namespace CourseWork.DataBase.Services
{
    public class UserService : IUserService
    {
        IUserRepository repository;
        public UserService(DbContext dbContext)
        {
            repository = new UserRepository(dbContext);
        }
        public void AddUser(User user)
        {
            UserEntity userentity = new()
            {
                Name = user.Name,
                Balance = user.Balance,
                Login = user.Login,
                Password = user.Password,
                History = user.History,
               
            };
            repository.Create(userentity);
        }

        public List<User> ReadUser()
        {
            return repository.Read().Select(Map).ToList();
        }

        public List<Purchase> GetPurchaseHistory(User user)
        {
            var purchaseHistory = ReadUser().FirstOrDefault(u => u.Login == user.Login).History;

            return purchaseHistory;
        }

        public void UpdateUserInDB(User user)
        {
            var userEntity = repository.Update(user.Login);
            userEntity.Balance = user.Balance;
            userEntity.History = user.History;
        }

        User Map(UserEntity userEntity)
        {
            User user = new(userEntity.Login, userEntity.Password, userEntity.Name, userEntity.Addres)
            {
                Balance = userEntity.Balance,
                History = userEntity.History
            };
            return user;
        }
    }
}
