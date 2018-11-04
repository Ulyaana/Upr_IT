using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uit
{
    class Program
    {
        static void Main(string[] args)
        {

            Example1();
            Console.ReadKey();
        }


        static void Example1()
        {

            Console.WriteLine("Оригинал: " + Console.ReadLine());
            string text = Console.ReadLine();
            string alph = "абвгдежзийклмнопрстуфхцчшыьэюя ."; // нет букв ё ъ щ
            string key = "";
            for (int i = 0; i < text.Length; i++)
            {
                Random rand = new Random();
                int num = rand.Next(0, alph.Length - 1);

                // Добавить письмо.
                key += alph[num];
            }

            var pad = new OnTimePad(alph);
            string encrypt = pad.Crypt1(text, key);

            Console.WriteLine("Шифротекст: " + encrypt);
        }
    }

    class OnTimePad
    {
        Dictionary<char, int> alph = new Dictionary<char, int>();
        Dictionary<int, char> alph_r = new Dictionary<int, char>();

        public OnTimePad(IEnumerable<char> Alphabet)
        {
            int i = 0;
            foreach (char c in Alphabet)
            {
                alph.Add(c, i);
                alph_r.Add(i++, c);
            }
        }



        public string Crypt1(string Text, string Key)
        {
            char[] key = Key.ToCharArray();
            char[] text = Text.ToCharArray();
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int ind;
                if (alph.TryGetValue(text[i], out ind))
                {
                    sb.Append(alph_r[(ind ^ alph[key[i % key.Length]]) % alph.Count]);
                }
            }

            return sb.ToString();
        }
    }
}
