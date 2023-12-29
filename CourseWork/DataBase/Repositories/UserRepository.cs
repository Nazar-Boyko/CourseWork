using CourseWork.DataBase.Enteties;
using CourseWork.DataBase.Repositories.Base;

namespace CourseWork.DataBase.Repositories
{

    public class UserRepository : IUserRepository
    {
        private DbContext dbContext;
        public UserRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(UserEntity user)
        {
            dbContext.Users.Add(user);
        }
 
        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> Read()
        {
            return dbContext.Users;
        }

        public UserEntity Update(string Login)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Login == Login);
            return user;
        }
    }
}
