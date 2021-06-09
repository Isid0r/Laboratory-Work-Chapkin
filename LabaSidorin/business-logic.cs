using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaSidorin
{
    class business_logic 
    {
        data_logic data = new data_logic();

        public void createText(string text)
        {
            data.createLine(text);
        }

        public void showText()
        {
            data.showAll();
        }

        public void updateText(string text, int numUser)
        {
            data.updateLine(text, numUser);
        }

        public void showLineB(int numUser)
        {
            data.showLine(numUser);
        }

        public string showAllForRoleB(string text)
        {
            string backStr = "";
            string str = "";
            for (int i = 0; i < data.dataList.Count; i++)
            {
                str = data.showAllForRole(text, i);
                if (str != "")
                backStr = string.Concat(backStr,"\n", str);
            }
            if (backStr != "")
                return backStr;
            else
                return "Такой роли нет!";

        }

        public string showAllForUserB(string text)
        {
            string backStr = "";
            string str = "";
            for (int i = 0; i < data.dataList.Count; i++)
            {
                str = data.showAllForUser(text, i);
                if (str != "")
                    backStr = string.Concat(backStr, "\n", str);
            }
            if (backStr != "")
                return backStr;
            else
                return "Такого имени нет!";

        }

        public bool verificationExistence(int numUser)  // Проверка, существует ли введенный пользователем элемент
        {
            if ((numUser >= data.dataList.Count) || (numUser < 0))
                return false;
            else
                return true;
        }

        public void deleteLineB(int numUser)
        {
            data.deleteLine(numUser);
        }

    }
}
