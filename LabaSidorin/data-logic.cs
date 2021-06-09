using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaSidorin
{
    class data_logic
    {

        private int counter = 0;
        public List<DataLine> dataList = new List<DataLine>();           // список, содержащий в себе элементы (разделенные строки) базы данных
        public string[] data = File.ReadAllLines(@"..\..\..\laba.txt");  // массив для построчного считывания файла
        public DataLine[] dataArr = new DataLine[0];                     // массив для перевода считанных строк в список


        public data_logic()
        {
            int counter = 0;

            foreach (var item in data)
            {
                Array.Resize(ref dataArr, dataArr.Length + 1);     // увеличивает размер массива на 1
                dataArr[counter] = new DataLine(item);
                counter++;
            }

            dataList.AddRange(dataArr);                            // добавляет преобразованный массив в список

        }

        public void createLine(string text)
        {
            Array.Resize(ref dataArr, dataArr.Length + 1);
            dataArr[dataArr.Length - 1] = new DataLine(text);
            dataList.Add(dataArr[dataArr.Length - 1]);

            StreamWriter writer = new StreamWriter(@"..\..\..\laba.txt", true); //создаем «потоковый писатель» и связываем его с файловым потоком 
            writer.WriteLine(text);
            writer.Close();

        }

        public void showLine(int numUser)
        {
                Console.WriteLine(dataList[numUser]);
                counter++;
        }

        public void updateLine(string text, int numUser)
        {
            dataArr[numUser] = new DataLine(text);
            dataList[numUser] = dataArr[numUser];


            StreamWriter writer = new StreamWriter(@"..\..\..\laba.txt", false);
            foreach (var item in dataList)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }

        public void deleteLine(int numUser)
        {
            dataList.RemoveAt(numUser);

            StreamWriter writer = new StreamWriter(@"..\..\..\laba.txt", false);
            foreach (var item in dataList)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }

        public string showAllForRole(string text, int numUser)
        {
            if (dataList[numUser].UserRole == text)
                return dataList[numUser].ToString();
            else
                return "";
        }

        public string showAllForUser(string text, int numUser)
        {
            if (dataList[numUser].UserName == text)
                return dataList[numUser].ToString();
            else
                return "";
        }

        public void showAll()
        {
            //foreach (var item in data)                    //выводит базу с файла
            //{
            //    Console.WriteLine(item);
            //}

            counter = 0;
            foreach (var item in dataList)                 //выводит базу из списка в программе
            {
                Console.WriteLine(counter + ". " + item);
                counter++;
            }
        }

    }
}
