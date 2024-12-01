namespace aoc_cs.util;

public abstract class Day(int number)
{
    public int Number { get; } = number;
    public abstract String Part1(string input);
    public abstract String Part2(string input);
}