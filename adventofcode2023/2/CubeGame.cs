namespace adventofcode2023._2;

public class CubeGame
{
    public CubeGame(string input)
    {
        var startIndex = 5;
        var endIndex = input.IndexOf(": ");

        GameNumber = int.Parse(input.Substring(startIndex, endIndex-startIndex));

        var gamePlaysStartIndex = endIndex + 2;
        foreach (var gamePlaysIndex in input.Substring(gamePlaysStartIndex).Split("; "))
        {
            var gamePlay = new CubeGamePlay(gamePlaysIndex);
            GamePlays.Add(gamePlay);
        }
    }

    public int GameNumber { get; }
    public List<CubeGamePlay> GamePlays { get; set; } = new();

    public bool IsPossible(int red, int green, int blue)
    {
        return GamePlays.All(x => x.RedCubeCount <= red && x.GreenCubeCount <= green && x.BlueCubeCount <= blue);
    }

    public int PowerOfMinimumCubes()
    {
        var maxRed = GamePlays.Max(x => x.RedCubeCount);
        var maxBlue = GamePlays.Max(x => x.BlueCubeCount);
        var maxGreen = GamePlays.Max(x => x.GreenCubeCount);

        return maxRed * maxBlue * maxGreen;
    }
}
public class CubeGamePlay
{
    public CubeGamePlay(string input)
    {
        var cubeCounts = input.Split(", ");
        foreach (var cubeCount in cubeCounts)
        {
            if (cubeCount.Contains("red"))
            {
                RedCubeCount = int.Parse(cubeCount.Substring(0, cubeCount.IndexOf(" ")));
            }

            if (cubeCount.Contains("blue"))
            {
                BlueCubeCount = int.Parse(cubeCount.Substring(0, cubeCount.IndexOf(" ")));
            }

            if (cubeCount.Contains("green"))
            {
                GreenCubeCount = int.Parse(cubeCount.Substring(0, cubeCount.IndexOf(" ")));
            }
        }
    }

    public int RedCubeCount { get; }
    public int BlueCubeCount { get; }
    public int GreenCubeCount { get; }
}