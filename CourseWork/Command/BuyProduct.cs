using CourseWork.Account;
using CourseWork.Command.Base;
using CourseWork.DataBase.Services;
using CourseWork.DataBase.Services.Base;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseWork.Command
{
    public class BuyProduct : ICommand
    {
        UserService userService;
        ProductService productService;
        public BuyProduct(UserService userService, ProductService productService)
        {
            this.userService = userService;
            this.productService = productService;
        }
        public void Execute(User user)
        {
            var products = productService.ReadProduct();
            if (products.Count == 0)
            {
                ProductNotExistInfo();
                Console.ReadLine();
            }
            else
            {
                var index = GetProduct(products);
                buyProduct(user, products, index);
            }
        }

        int GetProduct(List<Product> products)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\t\t\t\t\t\t    ПЕРЕЛІК ВСІХ ТОВАРІВ");
                for (int i = 0; i < products.Count; i++)
                {
                    ShowProduct(products[i], i + 1);
                }

                string result = $"\t\t\t{new string('─', 72)}\n" +
                                $"{new string(' ', 53)}Введіть номер товару\n" +
                                $"{new string(' ', 55)}╔══════════════╗\n" +
                                $"{new string(' ', 55)}║              ║\n" +
                                $"{new string(' ', 55)}╚══════════════╝\n" +
                                $"\t\t\t{new string('─', 72)}";
                Console.WriteLine(result);
                Console.SetCursorPosition(62, 5 + 10*products.Count);
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    if (index <= products.Count && index > 0)
                    {
                        return index;
                    }
                    else
                    {
                        Console.Write("\n\n\t\t\t   *** Продукту з таким індексом не існує, спробуйте знову ***");
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.Write("\n\n\t\t\t\t   *** Ви ввдели щось не те, спробуйте знову! ***");
                    Thread.Sleep(2000);
                }
            }
        }

        void ShowProduct(Product product, int index)
        {
            string top = $"\n\t\t\t╭──┬{new string('─', 67)}╮\n";
            string bottom = $"\t\t\t╰{new string('─', 70)}╯\n";
            top += $"\t\t\t│{index,2}│ {product.Name,-37}   Вартість товару: {product.Price}₴{new string(' ', 8 - product.Price.ToString().Length)}│\n" +
                   $"\t\t\t├──┴{new string('─', 67)}┤\n" +
                   $"\t\t\t│  Стан: {product.State,-8}{new string(' ', 54)}│\n" +
                   $"\t\t\t│  Товарів в наявності: {product.Quantity,2}{new string(' ', 45)}│\n" +
                   $"\t\t\t│{new string(' ', 70)}│\n" +
                   $"\t\t\t│  {product.Addres,-23}{new string(' ', 27)}{product.PublicationTime,17} │\n" +
                   bottom;
            Console.WriteLine(top);

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

        void ShowProductforPurchase(List<Product> products, int index)
        {
            Console.Clear();
            Product product = products[index-1];
            ShowProduct(product, index);
            Console.WriteLine($"\n\t\t\t{new string('─', 72)}" +
                   $"\n\t\t\t{new string(' ', 26)}Прекрасний вибір!!!\n" +
                   $"\n\t\t\t{new string(' ', 15)}Тепер введіть бажану кількість товарів: " +
                   $"\n\t\t\t{new string('─', 72)}");
            Console.SetCursorPosition(79, 14);
        }

        public void buyProduct(User user, List<Product> products, int index)
        {
            var product = products[index - 1];
            while (true)
            {
                ShowProductforPurchase(products, index);
                if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
                {
                    if (count <= product.Quantity)
                    {
                        int full_price = product.Price * count;
                        if (full_price <= user.Balance)
                        {
                            Console.Clear();

                            DateTime currentDate = DateTime.Now;
                            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("uk-UA");
                            var date = currentDate.ToString("dd MMMM yyyy", cultureInfo);

                            Purchase purchase = new(product, count, full_price, date);

                            user.Balance -= full_price;
                            product.Quantity -= count;

                            user.History.Add(purchase);
                            productService.UpdateProductQuantity(product);
                            userService.UpdateUserInDB(user);
                            if (product.Quantity == 0)
                            {
                                productService.DeleteProduct(product);
                            }
                            EndInfo();
                            break;
                        }
                        else 
                        {
                            Console.WriteLine("\n\n\t\t\t\t\t    *** У вас недостатньо коштів ***");
                            Console.WriteLine("\n\t\t\t\t\t\t1 - Зменшити кількість товарів");
                            Console.WriteLine("\n\t\t\t\t\t\t2 - Повернутись в головне меню");
                            Console.Write("\n\t\t\t\t\t\tОберіть дію: ");
                            var input = Console.ReadLine();
                            if (input == "1") { }
                            else if (input == "2") { break; }
                        }
                    }
                    else Error("\n\t\t\t\t\t*** Ви ввели завелику кількість товарів ***", 2000);
                }
                else Error("\n\t\t\t\t\t*** Ви ввели щось не те, спробуйте знову! ***", 2000);
            }
        }

        void EndInfo()
        {
            string tab = "\t\t\t\t  ";
            string output = $"\n{tab}╔══════════════════════════════════════════════════════════╗\n";
            output += $"{tab}║                ТРАНЗАКЦІЯ ПРОЙШЛА УСПІШНО                ║\n" +
                      $"{tab}╠══════════════════════════════════════════════════════════╣\n\n" +
                      $"{tab}     Товар прийде до вас у відділеня протягом 1-2 тижнів\n\n" +
                      $"{tab}     Щоб перейти в головне меню, натисніть Enter...\n\n"+
                      $"{tab}╚══════════════════════════════════════════════════════════╝";
            Console.WriteLine(output);
            Console.SetCursorPosition(85, 7);
            Console.ReadLine();
        }

        void Error(string text, int time)
        {
            Console.Write(text);
            Thread.Sleep(time);
        }

        public string GetInfo()
        {
            return "Придбати товар";
        }
    }
}
