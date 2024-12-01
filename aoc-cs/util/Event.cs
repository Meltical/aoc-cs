namespace aoc_cs.util;

public class Event(int year, List<Day> days)
{
    public int Year { get; set; } = year;
    public List<Day> Days { get; set; } = days;
}