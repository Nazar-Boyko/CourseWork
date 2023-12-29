using CourseWork.Account;
using CourseWork.Command.Base;
using CourseWork.DataBase.Services;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Command
{
    public class ShowPurchaseHistory : ICommand
    {
        UserService userService;
        public ShowPurchaseHistory(UserService userService)
        {
            this.userService = userService;
        }
        public void Execute(User user)
        {
            Console.Clear();
            var purchaseHistory = userService.GetPurchaseHistory(user);
            int top = 4;
            Console.WriteLine("\t\t\t   " + new string('─', 66));
            if (purchaseHistory.Count != 0)
            {
                Console.WriteLine($"\n{new string(' ', 52)}ІСТОРІЯ ПОКУПОК");
                foreach (var purchase in purchaseHistory)
                {
                    ShowPurchase(purchase);
                }
                top = 4 + purchaseHistory.Count * 8;

            }
            else
            {
                Console.WriteLine("\n\t\t\t\t\t\tВи не здійснювали покупок");

            }
            
            Console.WriteLine("\n\t\t\t\t   Щоб повернутись в головне меню, натисніть Enter...");
            Console.WriteLine("\n\t\t\t   " + new string('─', 66));
            Console.SetCursorPosition(85, top);
            Console.ReadLine();

        }

        private void ShowPurchase(Purchase purchase)
        {
            string result = $"\t\t\t\t  ╭{new string('─', 50)}╮\n";
            string name = purchase.Product.Name;
            int margin = (50 - name.Length) / 2;
            int i = (name.Length % 2 == 0) ? 0 : 1;
            result += $"\t\t\t\t  │{new string(' ', margin)}{name}{new string(' ', margin + i)}│\n" +
                      $"\t\t\t\t  ├{new string('─', 50)}┤\n" +
                      $"\t\t\t\t  │  Кількість: {purchase.Quantity, -2}{new string(' ', 35)}│\n" +
                      $"\t\t\t\t  │  Вартість покупки: {purchase.FullPrice}₴{new string(' ', 29 - purchase.FullPrice.ToString().Length)}│\n" +
                      $"\t\t\t\t  │{new string(' ',32)}{purchase.Date,17} │\n" +
                      $"\t\t\t\t  ╰{new string('─', 50)}╯\n";
            Console.WriteLine(result);
        }

        public string GetInfo()
        {
            return "Переглянути історію покупок";
        }
    }
}
