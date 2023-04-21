using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDictionary
{
    class App
    {
        public void Start(string fail)
        {
            try
            {
                string text = File.ReadAllText(fail);
                //Массив символов разделителей
                char[] separator = { '.' , ',' , ';' , ':' , '-' , ')' , '(' , '\n' , '\r' , '\t' , '?' , '!' , '`' , '\'' ,'[',']','/', '"' , '<' , '>' , '&' , '#' , '№' , '—' , '.' , '\u00AB' , '\u00BB' , '\u2026' , '\u2012' , '\u2013' , '\u2014' , '\u200B' , '\uFEFF' , '\u0020' , '\u00A0' };
                //Представление текста в виде массива слов, приедение к единому регистру, сортировка по алфавиту
                string[] words = text
                    .ToLower()
                    .Replace("\n", "")
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words);

                //Создание и заполнение словаря 
                Dictionary<string, int> dic = new Dictionary<string, int>();
                for (int i = 0; i < words.Length; i++)
                {
                    if (dic.ContainsKey(words[i]))
                    {
                        dic[words[i]]++;
                    }
                    else
                    {
                        dic.Add(words[i], 1);
                    }
                }
                //запись результата в новый файл

                string resultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frequencyDictionary.txt");
                using (var writer = new StreamWriter(resultFile))

                    foreach (var item in dic)
                    {
                        writer.WriteLine($"{item.Key}\t{item.Value}");
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }
    }
}
