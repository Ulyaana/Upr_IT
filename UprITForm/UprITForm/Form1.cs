using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UprITForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string text = textBox2.Text;
            string alph = "abcdefghijklmnopqrstuvwxyz .";
            string key = "";
            for (int i = 0; i < text.Length; i++)
            {
                Random rand = new Random();
                int num = rand.Next(0, alph.Length - 1);

                key += alph[num];
                var pad = new OnTimePad1(alph);
                string encrypt = pad.Crypt1(text, key);

                textBox4.Text = encrypt;
            }
        }
        class OnTimePad1
        {
            Dictionary<char, int> alph = new Dictionary<char, int>();
            Dictionary<int, char> alph_r = new Dictionary<int, char>();
            string letters = "abcdefghijklmnopqrstuvwxyz .";
            public OnTimePad1(IEnumerable<char> letters)
            {
                int i = 0;
                foreach (char c in letters)
                {
                    alph.Add(c, i);
                    alph_r.Add(i++, c);
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



            public string Crypt2(string Text, string Key)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
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
            string encrypt = pad.Crypt2(text, key);
            textBox3.Text = encrypt;
        }
    }
}
