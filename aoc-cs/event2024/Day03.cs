using System.Text.RegularExpressions;
using aoc_cs.util;

namespace aoc_cs.event2024;

public class Day03() : Day(3)
{
    public override string Part1(string input)
    {
        return CountMul(input).ToString();
    }

    private static readonly string[] Patterns = ["do()", "don't()"];

    public override string Part2(string input)
    {
        long sum = 0;
        var enabled = 1;
        var currentIdx = 0;
        int idx;
        while ((idx = input[currentIdx..].IndexOf(Patterns[enabled], StringComparison.Ordinal)) != -1)
        {
            if (enabled == 1) sum += CountMul(input.Substring(currentIdx, idx));

            currentIdx += idx + Patterns[enabled].Length;
            enabled = enabled == 1 ? 0 : 1;
        }

        if (enabled == 1) sum += CountMul(input[currentIdx..]);

        return sum.ToString();
    }

    private long CountMul(string notes)
    {
        var mulRe = new Regex(@"mul\((\d*),(\d*)\)");
        return mulRe.Matches(notes).Aggregate(0L,
            (acc, match) => acc += long.Parse(match.Groups[1].Value) * long.Parse(match.Groups[2].Value));
    }
}