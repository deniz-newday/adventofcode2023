namespace adventofcode2023._2;

public static class CubeGameService
{
    public static int TotalOfPossibleGames(string input)
    {
        var total = 0;
        foreach (var gameInputLine in input.Split(Environment.NewLine))
        {
            var game = new CubeGame(gameInputLine);

            if (game.IsPossible(12, 13, 14))
            {
                total += game.GameNumber;
            }
        }

        return total;
    }

    public static object TotalOfAllPowerOfMinimumGames(string input)
    {
        var total = 0;
        foreach (var gameInputLine in input.Split(Environment.NewLine))
        {
            var game = new CubeGame(gameInputLine);
            
            total += game.PowerOfMinimumCubes();
        }

        return total;
    }
}