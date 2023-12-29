
using CourseWork.Account;
using CourseWork.Command.Base;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CourseWork.Command
{
    public class CommandManager
    {
        public List<ICommand> Commands = new();

        public void AddCommand(ICommand command)
        {
            Commands.Add(command);
        }

        public List<object> ShowCommandforMainPage()
        {
            List<object> list = new();
            string res = "";
            int i = 1;
            foreach (var command in Commands)
            {
                res += $"\t\t│\t\t{i} ─ {command.GetInfo()}{new string(' ', 71 - command.GetInfo().Length)}│\n";
                i++;
            }
            list.Add(res);
            list.Add(Commands.Count);
            return list;
        }

        public void ExecuteCommand(int index, User user)
        {
            if (index >= 0 && index < Commands.Count)
            {
                Commands[index].Execute(user);
            }
        }
        
    }
}
