using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace regularExpressions
{
    class Program
    {
        //прив меня завут Жека, мой намер телефона (012) 345-67-89
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
                Regex regex = new Regex(@"(\(\d(\d{2})\) (\d{3}-\d{2}-\d{2}))");
                string phone_number = "+380 12 345 67 89";
                text = file.ReadToEnd().ToLower();
                for (int i = 0; i < wrongWords.Count; ++i)
                {
                    for (int j = 0; j < wrongWords[i].Count; ++j)
                    {
                        text = text.Replace(wrongWords[i][j], wrongWords[i][0]);
                    }
                }
                text = regex.Replace(text, phone_number);
            }
      
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write(text);
            }
        }
    } 
}
