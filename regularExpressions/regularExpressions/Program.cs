using System;
using System.Collections.Generic;
using System.IO;

namespace regularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> wrongWords = new List<List<string>>();
            string path = @"C:\Users\xxx-1\Desktop\lab5\regularExpressions\wrongWords.txt";
            string text ;
            using (StreamReader file = new StreamReader(path,System.Text.Encoding.Default))
            {
                string bufText;
                while ((bufText = file.ReadLine()) != null)
                {
                    string[] words = bufText.Split(' ');
                    List<string> wordsLine = new List<string>();
                    for (int el = 0; el < words.Length; ++el)
                    {
                        wordsLine.Add(words[el]);
                    }
                    wrongWords.Add(wordsLine);
                }
            }
 
            Console.Write("Введите путь: ");
            path = Console.ReadLine();

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                byte[] array = new byte[file.Length];
                file.Read(array, 0, array.Length);
                text = System.Text.Encoding.Default.GetString(array);
            }
        }
    }
}
