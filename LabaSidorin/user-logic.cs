using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaSidorin
{
    class user_logic
    {
        private int choice = 0;
        string text, text1;
        business_logic business = new business_logic();
        int numUser; // номер пользователя в выведенном списке

        public void dialog()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Здравствуйте. Что желаете сделать?\n\n" +
                    "1 - Добавить запись\n" +
                    "2 - Удалить запись\n" +
                    "3 - Отредактировать запись\n" +
                    "4 - Просмотреть конкретную запись\n" +
                    "5 - Просмотреть все записи\n" +
                    "6 - Вывести всех пользователей для роли\n" +
                    "7 - Вывести все роли для пользователя\n");

                text = Console.ReadLine();
                if (text.Length == 1)
                    choice = Int32.Parse(text);
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка!!!\nНеправильный ввод! Для продолжения работы нажмите ENTER!");
                    Console.ReadLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите имя пользователя, которого вы хотите добавить:");
                        text = Console.ReadLine();
                        if (text.IndexOf('-') != -1)
                        {
                            Console.Clear();
                            Console.WriteLine("Ай-ай-ай!! Символ \"-\" является служебным и запрещен в именах / ролях");
                            Console.ReadKey();
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("Введите его роль:");
                        text1 = Console.ReadLine();
                        if (text1.IndexOf('-') != -1)
                        {
                            Console.Clear();
                            Console.WriteLine("Ай-ай-ай!! Символ \"-\" является служебным и запрещен в именах / ролях");
                            Console.ReadKey();
                            break;
                        }
                        text = string.Concat(text,"-",text1);
                        business.createText(text);

                        break;

                    case 2:
                        Console.Clear();
                        
                        Console.WriteLine("Введите номер строки, которую хотите удалить:\n");
                        business.showText();
                        Console.WriteLine();
                        numUser = Int32.Parse(Console.ReadLine());
                        if (business.verificationExistence(numUser) == true)
                            business.deleteLineB(numUser);
                        else
                        {
                            Console.WriteLine("Ошибка!!!\nНеправильный ввод! Для продолжения работы нажмите ENTER!");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Выберите номер пользователя, информацию о котором вы хотите отредактировать:\n");
                        business.showText();
                        Console.WriteLine();

                        numUser = Int32.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine("Введите новое имя:");
                        text = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Введите новую роль:");
                        text = string.Concat(text, "-", Console.ReadLine());

                        business.updateText(text,numUser);
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введите номер строки, которую хотите посмотреть:");
                        numUser = Int32.Parse(Console.ReadLine());
                        if (business.verificationExistence(numUser) == true)
                            business.showLineB(numUser);
                        else
                            Console.WriteLine("Ошибка!!!\nНеправильный ввод! Для продолжения работы нажмите ENTER!");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Полный перечень пользователей:\n");
                        business.showText();
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Введите название роли:\n");
                        text = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Полный перечень пользователей для выбранной роли:");
                        Console.WriteLine(business.showAllForRoleB(text));
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("Введите имя пользователя:\n");
                        text = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Полный перечень ролей для выбранного пользователя:");
                        Console.WriteLine(business.showAllForUserB(text));
                        Console.ReadKey();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка!!!\nНеправильный ввод! Для продолжения работы нажмите ENTER!");
                        Console.ReadLine();
                        break;
                }
            }


        }
    }
}
