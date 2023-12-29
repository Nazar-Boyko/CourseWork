using CourseWork.Account;
using CourseWork.Command.Base;
using CourseWork.DataBase.Services;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Command
{
    public class ShowAllProduct : ICommand
    {
        ProductService productService;
        public ShowAllProduct(ProductService productService)
        {
            this.productService = productService;
        }
        public void Execute(User user = null)
        {
            Console.Clear();
            var products = productService.ReadProduct();
            if (products.Count == 0)
            {
                ProductNotExistInfo();
            }
            else
            {
                ShowProduct(products);
                NextAction(user, products.Count);
            }
            Console.ReadLine();
        }

        void ShowProduct(List<Product> products)
        {

            string top = $"\t\t\t╭──┬{new string('─',67)}╮\n";
            string bottom = $"\t\t\t╰{new string('─', 70)}╯\n";
            string result = "\n\t\t\t\t\t\t    ПЕРЕЛІК ВСІХ ТОВАРІВ\n\n";

            int i = 1;
            foreach (var product in products)
            {
                result += top +
                          $"\t\t\t│{i,2}│ {product.Name,-37}   Вартість товару: {product.Price}₴{new string(' ', 8 - product.Price.ToString().Length)}│\n" +
                          $"\t\t\t├──┴{new string('─', 67)}┤\n" +
                          $"\t\t\t│  Стан: {product.State,-8}{new string(' ',54)}│\n" +
                          $"\t\t\t│  Товарів в наявності: {product.Quantity,2}{new string(' ',45)}│\n" +
                          $"\t\t\t│{new string(' ', 70)}│\n" +
                          $"\t\t\t│  {product.Addres,-23}{new string(' ', 27)}{product.PublicationTime,17} │\n" +
                          bottom;
                i++;
            }
            Console.WriteLine(result);
        }

        private void NextAction(User user, int count)
        {
            string result = $"\n\t\t\t{new string('─', 72)}";

            int left;
            int top;

            if (user != null)
            {
                result += $"\n\t\t\t{new string(' ', 14)}Якщо ви хочете придбати якийсь товар, тоді...\n" +
                          $"\n\t\t\t{new string(' ', 11)}1) Перейдіть в головне меню" +
                          $"\n\t\t\t{new string(' ', 11)}2) Оберіть функцію \"Придбати товар\"\n" +
                          $"\n\t\t\t{new string(' ', 14)}Щоб перейти в головне меню, натисніть Enter...";

                left = 84;
                top = 11 + count * 8;
            }
            else
            {
                result += $"\n\t\t\t{new string(' ', 14)}Щоб повернутись назад, натисніть Enter...";
                left = 79;
                top = 6 + count * 8;
            }
            result += $"\n\t\t\t{new string('─', 72)}";
            Console.WriteLine(result);
            Console.SetCursorPosition(left, top);

        }

        private void ProductNotExistInfo()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n" +
                "\t\t\t────────────────────────────────────────────────────────────────────────────\n" +
                "\t\t\t\n\n" +
                "\t\t\t         УПС, ТОВАРІВ БІЛЬШЕ НЕ ЗАЛИШИЛОСЬ, ПРИХОДЬТЕ НАСТУПНОГО РАЗУ        \n" +
                "\t\t\t\n\n" +
                "\t\t\t────────────────────────────────────────────────────────────────────────────" +
                "\n\n\n"
                );
            Console.SetCursorPosition(93, 6);
        }

        public string GetInfo()
        {
            return "Переглянути всі товари";
        }
    }
}
