using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(130, 30);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            bool showMenu = true;
            string[] alf = {"А","Б","В","Г","Ґ","Д","Е","Є","Ж","З","И","І","Ї","Й","К","Л","М","Н","О","П","Р",
        "С","Т","У","Ф","Х","Ц","Ч","Ш","Щ","Ь","Ю","Я"};

            while (true)
            {
                if (showMenu)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < alf.Length; i++)
                    {
                        Console.Write("|" + alf[i] + "" + i);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n");

                    Console.WriteLine("Оберіть дію:");
                    Console.WriteLine("1. Зашифрувати текст");
                    Console.WriteLine("2. Розшифрувати текст");

                    Console.WriteLine();
                }
                ConsoleKeyInfo cki = Console.ReadKey(intercept: true);
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        showMenu = false;

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Введіть текст: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string text = Console.ReadLine().ToUpper();
                        int[] resultnumtext = textnum(alf, text);
                        foreach (int item in resultnumtext)
                        {
                            Console.Write(item + "|");
                        }

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Введіть ключ s: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        bool chks = false;
                        int keys = 0;
                        while (!chks)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out keys) && keys >= 0 && keys < alf.Length)
                            {
                                chks = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("------------------------------");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Введіть ключ s: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        } 

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Введіть ключ a: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        bool chka = false;
                        int keya = 0;
                        while (!chka)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out keya) && keya > 0 && keya < alf.Length)
                            {
                                for (int i = 0; i < alf.Length; i++)
                                {
                                    if (keya * i % alf.Length == 1)
                                    {
                                        chka = true;
                                        break;
                                    }
                                }
                            }
                            if (!chka)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("------------------------------");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Введіть ключ a: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Зашифрований текст");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int[] resultencryptednum = encryptednum(keya, keys, resultnumtext);
                        foreach (int item in resultencryptednum)
                        {
                            Console.Write(item + "|");
                        }
                        Console.WriteLine();
                        Console.WriteLine(textencryption(resultencryptednum, alf));
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("4. Очистити");
                        break;

                    case ConsoleKey.D2:
                    showMenu = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Введіть зашифрований текст: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string encryptedtext = Console.ReadLine().ToUpper();
                        int[] resultnumenctext = textnum(alf, encryptedtext);
                        foreach (int item in resultnumenctext)
                        {
                            Console.Write(item + "|");
                        }

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Введіть ключ s: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Int32.TryParse(Console.ReadLine().ToUpper(), out int decryptedkeys);
                           

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Введіть ключ a: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Int32.TryParse(Console.ReadLine().ToUpper(), out int decryptedkeya);
                        int[] resultnumdeckey = decryptednum(resultnumenctext,decryptedkeya,decryptedkeys);
                        foreach (int item in resultnumdeckey)
                        {
                            Console.Write(item + "|");
                        }
                        Console.WriteLine();

                        Console.WriteLine(textencryption(resultnumdeckey, alf));
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("4. Очистити");
                        break;

                        case ConsoleKey.D4:
                        Console.Clear();
                        showMenu = true;
                        break;

                        default:
                        showMenu = false;
                        break;
                }
            }
        }

    
        static int[] textnum(string[] alf, string text)
        {
            int[] resultnumtext = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alf.Length; j++)
                {
                    if (text[i].ToString() == alf[j])
                    {
                        resultnumtext[i] = j;
                    }
                }
            }
            return resultnumtext;
        }
        static int[] encryptednum(int keya, int keys, int[] textnum)
        {
            int[] resultencryptednum = new int[textnum.Length];
            for (int i = 0; i < resultencryptednum.Length; i++)
            {
                resultencryptednum[i] = (keya * textnum[i] + keys) % 33;
            }
            return resultencryptednum;
        }
        static string textencryption(int[] ecryptednum, string[] alf)
        {
            string encryptedtext = "";
            for (int i = 0; i < ecryptednum.Length; i++)
            {
                for (int j = 0; j < alf.Length; j++)
                {
                    if (ecryptednum[i] == j)
                    {
                        encryptedtext += alf[j].ToString();
                    }

                }
            }
            return encryptedtext;
        }
        static int[] decryptednum(int[] encnum,int keya, int keys)
        {
            int keyainv = 0;
            for (int i = 0; i < 33; i++)
            {
                if (keya * i % 33 == 1)
                {
                    keyainv = i % 33;
                    break;
                }
            }
            Console.WriteLine(keyainv);
            int[] resultdecryptednum = new int[encnum.Length];
            for (int i = 0; i < resultdecryptednum.Length; i++)
            {
                resultdecryptednum[i] = (keyainv * encnum[i] + ((-keyainv * keys) % 33 + 33) % 33) % 33;
            }
            return resultdecryptednum;
        }
    }
}
    