using CourseWork.Account;
using CourseWork.DataBase.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DataBase.Repositories.Base
{
    public interface IUserRepository
    {
        void Create(UserEntity user);
        List<UserEntity> Read();
        public UserEntity Update(string name);

        void Delete(string name);
    }
}
