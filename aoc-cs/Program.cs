using System.Diagnostics;
using aoc_cs.event2024;
using aoc_cs.util;

namespace aoc_cs;

public abstract class Program
{
    private static readonly List<Event> Events = [new Event(2024, [new Day01()])];

    public static void Main(string[] _)
    {
        foreach (Event e in Events)
        {
            foreach (Day d in e.Days)
            {
                Console.WriteLine($"{Ansi.Yellow}{e.Year} day {d.Number}{Ansi.Reset}");
                SolvePart(e, d, 1);
                SolvePart(e, d, 2);
            }
        }
    }

    private static void SolvePart(Event e, Day d, int part)
    {
        string? strAppPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
        if (strAppPath == null)
        {
            Console.WriteLine($"Part {part}: File not found");
            return;
        }

        String input = File.ReadAllText($"input/event{e.Year}/aoc_e{e.Year}_d{d.Number:00}_p{part}.txt");
        string
            result = part == 1 ? d.Part1(input) : d.Part2(input);
        Console.WriteLine($"    Part {part}: {Ansi.Bold}{Ansi.Red}{result}{Ansi.Reset}");
    }
}