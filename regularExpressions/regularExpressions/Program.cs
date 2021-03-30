using System;
using System.Collections.Generic;
using System.IO;

namespace regularExpressions
{
    class Program
    {
        //Прив меня завут Жека, мой намер телефона
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
                    string[] words = bufText.Split('#');
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

            using (StreamReader file = new StreamReader(path))
            {
                text = file.ReadToEnd().ToLower();
                for (int i = 0; i < wrongWords.Count; ++i)
                {
                    for (int j = 0; j < wrongWords[i].Count; ++j)
                    {
                        text = text.Replace(wrongWords[i][j], wrongWords[i][0]);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write(text);
            }
        }
    }
}
