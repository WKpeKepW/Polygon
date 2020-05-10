using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{/// <summary>
/// Класс генерируещий рандомный пароль
/// </summary>
    class RandomPass
    {/// <summary>
    /// Метод создающий радомный пароль
    /// </summary>
    /// <param name="mincolpass">минимально возможное кол-во символов в пароле</param>
    /// <param name="maxcolpass">максимальное возможное кол-во символов в пароле</param>
    /// <param name="randomstring">возможные символы в пароле</param>
    /// <returns></returns>
        public string Rass(int mincolpass = 5,int maxcolpass = 12,string randomstring = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890")
        {
            Random r = new Random();
            int masslenght = r.Next(mincolpass,maxcolpass);
            string[] massiv = new string[masslenght];
            char ch;
            int sim;
            string retr = null;
            for (int i = 0; i != massiv.Length; i++)
            {
                sim = r.Next(0, randomstring.Length);
                ch = randomstring[sim];
                massiv[i] = Convert.ToString(ch);
                retr = retr + massiv[i];
            }
            return retr;
        }
    }
}
