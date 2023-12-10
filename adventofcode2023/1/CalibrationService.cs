using System.Text;

namespace adventofcode2023._1;

public static class CalibrationService
{
    public static int GetValueForLine(string line)
    {
        var numberStringValues = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var numbers = new List<(int, int)>();

        for (var i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                numbers.Add((int.Parse(line[i].ToString()), i));
            }
        }

        foreach (var numberStringValue in numberStringValues)
        {
            var indexes = line.MultipleIndex(numberStringValue);
            foreach (var index in indexes)
            {
                var number = numberStringValues.ToList().IndexOf(numberStringValue);
                numbers.Add((number, index));
            }
        }

        return int.Parse($"{numbers.OrderBy(x => x.Item2).First().Item1}{numbers.OrderBy(x => x.Item2).Last().Item1}");
    }

    public static void GenerateOutput(string value)
    {
        var sw = new StringBuilder();
        foreach (var lineValue in value.Split(Environment.NewLine))
        {
            sw.AppendLine($"{lineValue}\t{GetValueForLine(lineValue)}");
        }

        File.WriteAllText("output.txt", sw.ToString());
    }

    public static int GetValueForAllLines(string value)
    {
        var total = 0;
        foreach (var lineValue in value.Split(Environment.NewLine))
        {
            total += GetValueForLine(lineValue);
        }
        return total;
    }
}
public static class Extensions
{
    public static int[] MultipleIndex(this string stringValue, string subString)
    {
        var indexes = new List<int>();
        for (var j = 0; j < stringValue.Length; j++)
        {
            if (stringValue.Substring(j).StartsWith(subString))
            {
                indexes.Add(j);
            }
        }
        return indexes.ToArray();
    }
}