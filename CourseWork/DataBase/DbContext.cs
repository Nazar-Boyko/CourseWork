using CourseWork.Account;
using CourseWork.DataBase.Enteties;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DataBase
{
    public class DbContext
    {
        public List<UserEntity> Users { get; set; }
        public List<ProductEntity> Products { get; set; }

        public DbContext()
        {
            Users = new()
            {
                new UserEntity {Login = "nazar_boyko", Name = "Назар", Password = "nanana123", Addres = "Хмельницький"}
            };

            Products = new()
            {
                new ProductEntity {Quantity = 12, Name = "Пуховик TNF 700", Type = ProductType.Clothes, Price = 7120,
                             Addres = "Київ, Дніпровський", PublicationTime = "20 грудня 2023р", State = "Нове"},

                new ProductEntity {Quantity = 7, Name = "Чоловічі Джинси buggy", Type = ProductType.Clothes, Price = 1250,
                             Addres = "Київ, Печерсткий", PublicationTime = "Сьогодні о 09:12", State = "Нове"},

                new ProductEntity {Quantity = 37, Name = "Чоловіча футболка Adidas", Type = ProductType.Clothes, Price = 320,
                             Addres = "Старокостянтинів", PublicationTime = "15 грудня 2023р", State = "Нове"},

                new ProductEntity {Quantity = 12, Name = "Олімпійка KAPPA", Type = ProductType.Clothes, Price = 540,
                             Addres = "Зарічне", PublicationTime = "20 грудня 2023р", State = "Вживане"},

                new ProductEntity {Quantity = 1, Name = "Меблі в дитячу кімнату", Type = ProductType.Furniture,Price = 6000,
                             Addres = "Гримайлів", PublicationTime = "1 грудня 2023р", State = "Вживане"},

                new ProductEntity {Quantity = 1, Name = "Столик скляний", Type = ProductType.Furniture, Price = 800,
                             Addres = "Одеса, Київський", PublicationTime = "Вчора о 12:30", State = "Новий"},

                new ProductEntity {Quantity = 7, Name = "Ігрове крісло", Type = ProductType.Furniture, Price = 3500,
                             Addres = "Шегині", PublicationTime = "25 грудня 2023р", State = "Нове"},

                new ProductEntity {Quantity = 1, Name = "Стіл дерев'яний для тераси", Type = ProductType.Furniture, Price = 8000,
                             Addres = "Павшино", PublicationTime = "19 грудня 2023р", State = "Вживане"},

                new ProductEntity {Quantity = 1, Name = "Iphone 13pro 128Gb Black", Type = ProductType.Electronics, Price = 26500,
                             Addres = "Кременчук", PublicationTime = "25 грудня 2023р", State = "Вживане"},

                new ProductEntity {Quantity = 1, Name = "Шкіряний чохол-книжка Xiaomi Redmi", Type = ProductType.Electronics, Price = 50,
                             Addres = "Олександрівка", PublicationTime = "1 листопада 2023р", State = "Вживане"},

                new ProductEntity{Quantity = 1, Name = "Чохол накладка Aplle", Type = ProductType.Electronics, Price = 250,
                             Addres = "Ямпіль", PublicationTime = "20 грудня 2023р", State = "Нове"},

                new ProductEntity {Quantity = 1, Name = "Фітнест-браслет Mi Band 5", Type = ProductType.Electronics, Price = 500,
                             Addres = "Київ, Подільський", PublicationTime = "Вчора 20:23", State = "Вживане"},

                new ProductEntity {Quantity = 5, Name = "Силіконовий Ремінець для AppleWatch", Type = ProductType.Electronics, Price = 349,
                             Addres = "Харків, Холодногірський", PublicationTime = "14 грудня 2023р", State = "Нове"},
                
            };
        }
    }
}
