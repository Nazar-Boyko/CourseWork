using CourseWork.Account;
using CourseWork.DataBase.Services;

namespace CourseWork.Command
{
    public class LogIn
    {
        UserService userService;
        public LogIn(UserService userService)
        {
            this.userService = userService;
        }
        
        public User Execute()
        {
            while (true)
            {
                Console.Clear();
                ShowLogInForm();

                var login = Console.ReadLine();
                Console.SetCursorPosition(50, 13);

                var password = Console.ReadLine();
                var user = CheckUserInDB(login, password);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    Error("У вас не правильний логін або пароль, спробуйте знову", 2000);
                }
            }
        }


        private User CheckUserInDB(string login, string password)
        {
            var users = userService.ReadUser();
            var user = users.FirstOrDefault(u => u.Login == login && u.Password == password);
            return user;
        }


        private void Error(string text, int time)
        {
            Console.Write( "\n\n\n\t\t\t\t  *** "+ text+ " ***");
            Thread.Sleep(time);
        }


        private void ShowLogInForm()
        {
            string form = "\n\n" +
                          "\t\t\t\t╭────────────────────────────────────────────────────────────────╮\n" +
                          "\t\t\t\t│                                                                │\n" +
                          "\t\t\t\t│                           Авторизація                          │\n" +
                          "\t\t\t\t│                                                                │\n" +
                          "\t\t\t\t│               Логін                                            │\n" +
                          "\t\t\t\t│               ╔═════════════════════════════════╗              │\n" +
                          "\t\t\t\t│               ║                                 ║              │\n" +
                          "\t\t\t\t│               ╚═════════════════════════════════╝              │\n" +
                          "\t\t\t\t│                                                                │\n" +
                          "\t\t\t\t│               Пароль                                           │\n" +
                          "\t\t\t\t│               ╔═════════════════════════════════╗              │\n" +
                          "\t\t\t\t│               ║                                 ║              │\n" +
                          "\t\t\t\t│               ╚═════════════════════════════════╝              │\n" +
                          "\t\t\t\t│                                                                │\n" +
                          "\t\t\t\t╰────────────────────────────────────────────────────────────────╯\n";

            Console.Write(form);
            Console.SetCursorPosition(50, 8);
        }
    }
}
