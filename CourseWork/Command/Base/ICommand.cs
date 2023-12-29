

using CourseWork.Account;
using System.Globalization;

namespace CourseWork.Command.Base
{
    public interface ICommand
    {
        void Execute(User user = null);
        string GetInfo();
    }
}
