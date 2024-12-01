using aoc_cs.util;

namespace aoc_cs.event2024;

public class Day01() : Day(1)
{
    public override string Part1(string input)
    {
        var (left, right) = ParseInput(input);
        left.Sort();
        right.Sort();
        return left.Zip(right, (l, r) => Math.Abs(l - r)).Sum().ToString();
    }

    public override string Part2(string input)
    {
        var (left, right) = ParseInput(input);
        var freq = right.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        return left.Sum(x => x * freq.GetValueOrDefault(x)).ToString();
    }

    private (List<long>, List<long>) ParseInput(string input)
    {
        var tuples = input
            .Split(Environment.NewLine)
            .Select(x => x.Split("   "))
            .Select(x => (long.Parse(x[0]), long.Parse(x[1])))
            .ToList();
        return (tuples.Select(x => x.Item1).ToList(), tuples.Select(x => x.Item2).ToList());
    }
}