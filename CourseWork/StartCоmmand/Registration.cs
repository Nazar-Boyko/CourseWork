using CourseWork.Command.Base;
using CourseWork.Account;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CourseWork.DataBase.Services;
using System.Xml.Serialization;

namespace CourseWork.StartCоmmand
{
    public class Registration
    {
        UserService userService;
        public Registration(UserService userService)
        {
            this.userService = userService;
        }
        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                ShowRegistrForm();
                var login = TakeLogin();
                if (login != null)
                {
                    var name = TakeName();
                    if (name != null) {
                        var password = TakePassword();
                        if (password != null)
                        {
                            var addres = Console.ReadLine();
                            User user = new(login, password, name, addres);
                            userService.AddUser(user);
                            NextActions(name);
                            break;
                        }
                    }
                }

            }
        }


        private string TakeLogin()
        {
            var users = userService.ReadUser();
            var input = Console.ReadLine();

            if (input == "" || input == " ")
            {
                Clear("Ви задали пустий логін, спробуйте ще раз!", 2000);
                return null;
            }
            if (!users.Any(user => user.Login == input)) 
            {
                
                Console.SetCursorPosition(46, 14);
                return input;
            }
            else
            {
                Clear("Користувач з таким логіном вже існує, вигадайте інший", 2000);
                return null;
            }

        }
        private string TakeName()
        {
            var input = Console.ReadLine();
            if (input == "" || input == " ")
            {
                Clear("Ви не ввели свого імені, спробуйте ще раз!", 2000);
                return null;
            }
            else
            {
                Console.SetCursorPosition(46, 21);
                return input;
            }
        }


        private string TakePassword()
        {

            var input = Console.ReadLine();
            if (input == "" || input == " ")
            {
                Clear("Ви задали пустий пароль, спробуйте ще раз!", 2000);
                return null;

            }
            else if (6 > input.Length || input.Length > 20)
            {
                Clear("Ваш пароль не підходить за розміром, спробуйте ще раз", 2000);
                return null;

            }
            else if (!PasswordReliability(input))
            {
                Clear("Ваш пароль не надійний, вигадайте інший", 2000);
                return null;

            }
            else
            {
                Console.SetCursorPosition(46, 27);
                return input;
            }
        }
        private bool PasswordReliability(string input)
        {
            return input.Any(c => char.IsDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c));
        }

        private void ShowRegistrForm()
        {
            string form = "\n\n" +
                          "\t\t\t    ╭────────────────────────────────────────────────────────────────╮\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    │                           Реєстарація                          │\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    │               Логін (можна вписати E-mail, телефон і тд)       │\n" +
                          "\t\t\t    │               ╔═════════════════════════════════╗              │\n" +
                          "\t\t\t    │               ║                                 ║              │\n" +
                          "\t\t\t    │               ╚═════════════════════════════════╝              │\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    │               Ваше ім'я                                        │\n" +
                          "\t\t\t    │               ╔═════════════════════════════════╗              │\n" +
                          "\t\t\t    │               ║                                 ║              │\n" +
                          "\t\t\t    │               ╚═════════════════════════════════╝              │\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    │               Пароль (обов'язково цифри та літери)             │\n" +
                          "\t\t\t    │               Довжина паролю від 6 до 20 символів              │\n" +
                          "\t\t\t    │               ╔═════════════════════════════════╗              │\n" +
                          "\t\t\t    │               ║                                 ║              │\n" +
                          "\t\t\t    │               ╚═════════════════════════════════╝              │\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    │               Адреса Нової пошти                               │\n" +
                          "\t\t\t    │               ╔═════════════════════════════════╗              │\n" +
                          "\t\t\t    │               ║                                 ║              │\n" +
                          "\t\t\t    │               ╚═════════════════════════════════╝              │\n" +
                          "\t\t\t    │                                                                │\n" +
                          "\t\t\t    ╰────────────────────────────────────────────────────────────────╯\n";

            Console.Write(form);
            Console.SetCursorPosition(46, 8);
        }
        private void NextActions(string name)
        {
            Console.Clear();
            string tab = "\t\t\t\t  ";

            string output = $"{tab}╔══════════════════════════════════════════════════════════╗\n";
            string text = $"Вітаємо, {name}! Ви успішно зареєстровані.";

            int len = (output.Length - text.Length - 6) / 2;


            output += $"{tab}║                РЕЄСТРАЦІЮ ПРОЙШЛА УСПІШНО                ║\n" +
                      $"{tab}╠══════════════════════════════════════════════════════════╣\n\n" +
                      $"{tab}{new string(' ', len)}{text}{new string(' ', len)}\n\n" +
                      $"{tab}        Щоб повернутись назад натисність Enter...  \n\n" +
                      $"{tab}╚══════════════════════════════════════════════════════════╝";


            Console.WriteLine("\n" + output);
            Console.SetCursorPosition(83, 7);
            Console.ReadLine();
        }



        private void Clear(string text, int time)
        {
            Console.SetCursorPosition(30, 32);
            Console.Write("****  " + text + " ****");
            Thread.Sleep(time);
        }
    }
}
