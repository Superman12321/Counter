using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Models
{
    public class AllCounters
    {
        public List<Counter> List { get; private set; } = new();

        public void AddCounters(Counter counter)
        {
            List.Add(counter);
        }

        public void SaveCounters(string path)
        {
            var writer = new StreamWriter(path, false);
            for (int i = 0; i < List.Count; i++)
            {
                writer.WriteLine(List[i].GetSaveLine());
            }
            writer.Close();
        }

        public void LoadCountes(string path)
        {
            var lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length < 2) continue;

                string name = parts[0].Trim();
                int number = Convert.ToInt32(parts[1].Trim());

                var counter = new Counter(name, number);
                List.Add(counter);
            }
        }
    }
}
