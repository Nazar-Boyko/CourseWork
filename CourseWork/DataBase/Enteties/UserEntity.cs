using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DataBase.Enteties
{
    public class UserEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }

        public int Balance { get; set; }

        public string Addres { get; set; }

        public List<Purchase> History { get; set; } = new();

    }
}
