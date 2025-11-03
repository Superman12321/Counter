using System.Collections.Generic;

namespace Counter.Models;
public class Counter
{
    public string Name { get; set; }
    public int Count { get; set; }

    public Counter(string name, int count)
    {
        Name = name;
        Count = count;
    }

    public string GetSaveLine()
    {
        return $"{Name},{Count}";
    }
}