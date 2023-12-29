using CourseWork.Account;
using CourseWork.Command;
using CourseWork.DataBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace CourseWork.StartCоmmand
{
    public class Start
    {
        UserService userService;

        public Start(UserService userService)
        {
            this.userService = userService;
        }
        public void Execute(CommandManager manager)
        {
            Registration registration = new(userService);
            LogIn logIn = new(userService);

            while (true)
            {
                ShowStartPage(manager);
                var input = Console.ReadLine();
                if (input == "1")
                {
                    registration.Execute();
                }
                else if (input == "2")
                {
                    var user = logIn.Execute();

                    while (true)
                    {
                        ShowMainPage(user, manager);
                        int choice;
                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            choice -= 1;
                            if (choice == manager.Commands.Count) break;
                            else if (choice < manager.Commands.Count) manager.ExecuteCommand(choice, user);
                            else
                            {
                                Console.Write("\n\n\n\t\t\t\t\t *** Не відома команда, спробуйте ще раз! ***");
                                Thread.Sleep(2000);
                            }
                        }
                        else
                        {
                            Console.Write("\n\n\n\t\t\t\t\t *** Ви ввели щось не те, спробуйте ще раз. ***");
                            Thread.Sleep(2000);
                        }
                    }
                }
                else if (input == "3")
                {
                    var command = manager.Commands.FirstOrDefault(command => command.GetInfo() == "Переглянути всі товари");
                    command.Execute();
                }
                else if (input == "4")
                {
                    EndMessage();
                    break;
                }
                else
                {
                    Console.Write("\n\n\t\t\t\t    **** Ви ввели щось не те. Спробуйте знову! ****");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        private void ShowMainPage(User user, CommandManager manager)
        {
            Console.Clear();

            var actions = (string)manager.ShowCommandforMainPage()[0];
            var count = (int)manager.ShowCommandforMainPage()[1];

            string top = $"╭{new string('─', 90)}╮";
            string mardin = new string(' ', user.Name.Length / 2);
            string balance = $"Баланс: {user.Balance}₴";
            string outbalance = $"│{mardin}{balance}{mardin}";
            string name = $"{mardin}{user.Name}{mardin}";
            int len = mardin.Length * 2 + balance.Length;
            string line = new string('─', len);

            string result = "\n\t\t" + top +
                      $"\n\t\t│{new string(' ', top.Length - 2)}│\n" +
                      $"\t\t│\t\t    █▀█ █   ▀▄▀{new string(' ', top.Length - name.Length - 32)}{name}│\n" +
                      $"\t\t│\t\t    █▄█ █▄▄ █ █{new string(' ', top.Length - 32)}│\n" +
                      $"\t\t│{new string(' ', top.Length - 3 - line.Length)}╭{line}┤\n" +
                      $"\t\t│\t\t   OLX ─ ЗНАЙ ДЕ!{new string(' ', top.Length - 34 - outbalance.Length)}{outbalance}│\n" +
                      $"\t\t│{new string(' ', top.Length - 3 - line.Length)}╰{line}┤\n" +
                      $"\t\t│{new string(' ', top.Length - 2)}│\n" +
                      $"\t\t│\t\t    Оберіть дію{new string(' ', top.Length - 32)}│\n" +
                      $"\t\t│{new string(' ', top.Length - 2)}│\n" +
                      actions +
                      $"\t\t│\t\t{count + 1} ─ Вийти з аккаунту{new string(' ', 55)}│\n" +
                      $"\t\t│{new string(' ', top.Length - 2)}│\n" +
                      $"\t\t│\t\t┏━━━━━━━━━━━━━┓{new string(' ', top.Length - 32)}│\n" +
                      $"\t\t│\t\t┃             ┃{new string(' ', top.Length - 32)}│\n" +
                      $"\t\t│\t\t┗━━━━━━━━━━━━━┛{new string(' ', top.Length - 32)}│\n" +
                      $"\t\t│{new string(' ', top.Length - 2)}│\n" +
                      $"\t\t╰{new string('─', 90)}╯\n";
            Console.WriteLine(result);

            Console.SetCursorPosition(39, 14 + count);
        }

        private void EndMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n" +
                "\t\t\t────────────────────────────────────────────────────────────────────────────\n" +
                "\t\t\t\n\n" +
                "\t\t\t                   МИ СПОДАВАЄМОСЬ ЩО ВИ ЗНАЙШЛИ ТЕ ЩО ШУКАЛИ!            \n" +
                "\t\t\t\n\n" +
                "\t\t\t────────────────────────────────────────────────────────────────────────────" +
                "\n\n\n"
                );
        }

        private void ShowStartPage(CommandManager manager)
        {
            Console.Clear();
            string tab = "\t\t\t\t";
            string result = $"\n{tab}\t\t░█████╗░██╗░░░░░██╗░░██╗" +
                            $"\n{tab}\t\t██╔══██╗██║░░░░░╚██╗██╔╝" +
                            $"\n{tab}\t\t██║░░██║██║░░░░░░╚███╔╝░" +
                            $"\n{tab}\t\t██║░░██║██║░░░░░░██╔██╗░" +
                            $"\n{tab}\t\t╚█████╔╝███████╗██╔╝╚██╗" +
                            $"\n{tab}\t\t░╚════╝░╚══════╝╚═╝░░╚═╝\n\n\n";

            result += $"{tab}   =================================================\n" +
                      $"{tab}                                                    \n" +
                      $"{tab}         Вітаємо вас на неофіційному сайті Olx       \n" +
                      $"{tab}         Тут ви знайдете все і навіть більше!        \n" +
                      $"{tab}                                                    \n" +
                      $"{tab}   =================================================\n\n\n";

            result += "\t\t\t   ╭──────────────────────────────────────────────────────────────╮\n" +
                      "\t\t\t   │                           Оберіть дію                        │\n" +
                      "\t\t\t   │                                                              │\n" +
                      "\t\t\t   │                    1 - Зареєструватись                       │\n" +
                      "\t\t\t   │                    2 - Увійти в аккаунт                      │\n" +
                      "\t\t\t   │                    3 - Переглянути товари                    │\n" +
                      "\t\t\t   │                    4 - Завершити роботу                      │\n" +
                      "\t\t\t   │                                                              │\n" +
                      "\t\t\t   │                       ╔══════════════╗                       │\n" +
                      "\t\t\t   │                       ║              ║                       │\n" +
                      "\t\t\t   │                       ╚══════════════╝                       │\n" +
                      "\t\t\t   ╰──────────────────────────────────────────────────────────────╯";

            Console.WriteLine(result);
            Console.SetCursorPosition(58, 26);

        }
    }
}
