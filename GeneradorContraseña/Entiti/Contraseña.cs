using Gabriel.Cat.S.Binaris;
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
        static GeneradorArchivoFacilDeLeer.Reader<string> reader;
        static Contraseña()
        {

            r = new Random();
            reader = new GeneradorArchivoFacilDeLeer.Reader<string>(Resources.PalabrasDic,ElementoBinario.ElementoTipoAceptado(Gabriel.Cat.S.Utilitats.Serializar.TiposAceptados.String));


        }
        public static string IGetRandom(int numPasswords=3)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < numPasswords; i++)
                str.Append(reader[r.Next(reader.Count)]);
            return str.ToString();
        }
        public static string GetRandom(int numPasswords = 3,int maxLength=-1)
        {
            const int MAX = 1 * 1000;
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
    }

}
