using CourseWork.Account;
using CourseWork.Command.Base;
using CourseWork.DataBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CourseWork.Command
{
    internal class ReplenishmentBalance : ICommand
    {
        UserService userService;
        public ReplenishmentBalance(UserService userService)
        {
            this.userService = userService;
        }
        public void Execute(User user)
        {
            while (true)
            {
                Console.Clear();
                Show();
                var input = Console.ReadLine();
                
                if (int.TryParse(input, out int money))
                {
                    if (money > 0)
                    {
                        user.Balance += money;
                        userService.UpdateUserInDB(user);
                        Console.WriteLine($"\n\tВаш баланс успішно поповнено на {money} гривень");
                        Console.Write($"\tЩоб перейти в головне меню, натисніть Enter...");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.Write("\n\tВи ввели від'ємне число або 0, спробуйте знову!");
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.Write("\n\tВи ввели щось не те, спробуйте знову");
                    Thread.Sleep(2000);
                }
            }
        }

        public string GetInfo()
        {
            return "Поповнити баланс";
        }

        private void Show()
        {
            string result = "\n\tВведіть суму для повонення\n" +
                            "\t╔══════════════╗\n" +
                            "\t║              ║\n" +
                            "\t╚══════════════╝\n";

            Console.WriteLine(result);
            Console.SetCursorPosition(10, 3);
        }
    }
}
