using aoc_cs.util;

namespace aoc_cs.event2024;

public class Day02() : Day(2)
{
    public override string Part1(string input)
    {
        return ParseInput(input).Where(IsValid).Count().ToString();
    }

    public override string Part2(string input)
    {
        var sum = 0;
        foreach (var report in ParseInput(input))
        {
            if (IsValid(report))
            {
                sum++;
                continue;
            }

            for (var i = 0; i < report.Count; i++)
            {
                List<long> changed = [..report];
                changed.RemoveAt(i);
                if (IsValid(changed))
                {
                    sum++;
                    break;
                }
            }
        }

        return sum.ToString();
    }

    private List<List<long>> ParseInput(string input)
    {
        return input
            .Split(Environment.NewLine)
            .Select(x => x.Split(' ').Select(long.Parse).ToList())
            .ToList();
    }

    private bool IsValid(List<long> report)
    {
        var isLess = report[0] < report[1];
        for (var i = 1; i < report.Count; i++)
        {
            var prev = report[i - 1];
            var val = report[i];
            var diff = Math.Abs(prev - val);
            if ((prev < val) != isLess || diff == 0 || diff > 3)
            {
                return false;
            }
        }

        return true;
    }
}