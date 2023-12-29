using CourseWork.Command;
using CourseWork.DataBase;
using CourseWork.DataBase.Services;
using CourseWork.StartCоmmand;
using System.Runtime.InteropServices;
using System.Text;

namespace CourseWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            DbContext dbContext = new();
            UserService userService = new(dbContext);
            ProductService productService = new(dbContext);
            var manager = new CommandManager();

            manager.AddCommand(new ReplenishmentBalance(userService));
            manager.AddCommand(new ShowAllProduct(productService));
            manager.AddCommand(new BuyProduct(userService, productService));
            manager.AddCommand(new ShowPurchaseHistory(userService));

            var start = new Start(userService);
            start.Execute(manager);

        }

    }
}