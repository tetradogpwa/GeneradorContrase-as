using GeneradorContraseña.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorContraseña.Entiti
{
    public class Contraseña
    {
        static Random r;
       static SortedList<int, string> Dictionary;
        static Contraseña()
        {
            string linea;
            bool correcto;
            StringReader stringReader = new StringReader(Resources.Palabras);
            int pos = 0;
            r = new Random();
            Dictionary = new SortedList<int, string>();
            do
            {
                linea = stringReader.ReadLine();
                correcto = !Equals(linea, default);
                if (correcto)
                     Dictionary.Add(pos++, linea);

            } while (correcto);

        }
        public static string IGetRandom(int numPasswords=3)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < numPasswords; i++)
                str.Append(Dictionary[r.Next(Dictionary.Count)]);
            return str.ToString();
        }
        public static string GetRandom(int numPasswords = 3,int maxLength=-1)
        {
            const int MAX = 100 * 1000;
            int intento = 0;
            string password;
            if (maxLength > 0)
            {
                do
                {
                    password = IGetRandom(numPasswords);
                    intento++;
                } while (password.Length > maxLength&&intento<MAX);
                if (intento == MAX)
                    password = String.Empty;
            }
            else password = IGetRandom(numPasswords);
            return password;
        }
        public static async Task Init() { }
        public static string[] GetValues() => Dictionary.Values.ToArray();
    }

}
