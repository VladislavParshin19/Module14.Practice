using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14.Practice
{
    class Program
    {
        static void Main()
        {
            string text = "Вот дом, Который построил Джек. А это пшеница, Кото­рая в темном чулане хранится В доме, Который построил Джек. А это веселая птица­ синица, Которая часто вору­ет пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

            Dictionary<string, int> wordStatistics = CountWordOccurrences(text);

            DisplayStatisticsTable(wordStatistics);

            Console.ReadLine();
        }

        static Dictionary<string, int> CountWordOccurrences(string text)
        {
            // Разделение текста на слова и подсчёт их вхождений
            string[] words = text.Split(new[] { ' ', ',', '.', '-', '—' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            return wordCount;
        }

        static void DisplayStatisticsTable(Dictionary<string, int> wordStatistics)
        {
            // Вывод статистики в виде таблицы
            Console.WriteLine("|    Слово    | Количество |");
            Console.WriteLine("|-------------|------------|");

            foreach (var repeat in wordStatistics.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("|{0,10}   |{1,10}  |", repeat.Key, repeat.Value);
            }
        }
    }
}
