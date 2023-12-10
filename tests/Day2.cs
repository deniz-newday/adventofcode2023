using adventofcode2023;
using adventofcode2023._2;
using Shouldly;
using Xunit;

namespace tests;

public class Day2
{
    [Fact]
    public void GivenFirstGame_ShouldTellGameNumber()
    {
        var game = new CubeGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

        Assert.Equal(1, game.GameNumber);
        Assert.Equal(3, game.GamePlays.Count);
        Assert.Equal(3, game.GamePlays[0].BlueCubeCount);
        Assert.Equal(4, game.GamePlays[0].RedCubeCount);
        Assert.Equal(1, game.GamePlays[1].RedCubeCount);
        Assert.Equal(2, game.GamePlays[1].GreenCubeCount);
        Assert.Equal(6, game.GamePlays[1].BlueCubeCount);
        Assert.Equal(2, game.GamePlays[2].GreenCubeCount);
    }

    [Fact]
    public void GivenSecondGame_ShouldTellGameNumber()
    {
        var game = new CubeGame("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");

        Assert.Equal(2, game.GameNumber);
        Assert.Equal(3, game.GamePlays.Count);
        var firstGame = game.GamePlays[0];
        var secondGame = game.GamePlays[1];
        var thirdGame = game.GamePlays[2];
        firstGame.BlueCubeCount.ShouldBe(1);
        firstGame.GreenCubeCount.ShouldBe(2);

        secondGame.GreenCubeCount.ShouldBe(3);
        secondGame.BlueCubeCount.ShouldBe(4);
        secondGame.RedCubeCount.ShouldBe(1);

        thirdGame.GreenCubeCount.ShouldBe(1);
        thirdGame.BlueCubeCount.ShouldBe(1);
    }

    [Fact]
    public void GivenThirdGame_ShouldTellGameNumber()
    {
        var game = new CubeGame("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");

        Assert.Equal(3, game.GameNumber);
        Assert.Equal(3, game.GamePlays.Count);
        var firstGame = game.GamePlays[0];
        var secondGame = game.GamePlays[1];
        var thirdGame = game.GamePlays[2];

        firstGame.BlueCubeCount.ShouldBe(6);
        firstGame.GreenCubeCount.ShouldBe(8);
        firstGame.RedCubeCount.ShouldBe(20);

        secondGame.GreenCubeCount.ShouldBe(13);
        secondGame.BlueCubeCount.ShouldBe(5);
        secondGame.RedCubeCount.ShouldBe(4);

        thirdGame.GreenCubeCount.ShouldBe(5);
        thirdGame.RedCubeCount.ShouldBe(1);
    }

    [Fact]
    public void GivenFourthGame_ShouldTellGameNumber()
    {
        var game = new CubeGame("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");

        Assert.Equal(4, game.GameNumber);
        Assert.Equal(3, game.GamePlays.Count);

        var firstGame = game.GamePlays[0];
        var secondGame = game.GamePlays[1];
        var thirdGame = game.GamePlays[2];

        firstGame.BlueCubeCount.ShouldBe(6);
        firstGame.GreenCubeCount.ShouldBe(1);
        firstGame.RedCubeCount.ShouldBe(3);

        secondGame.GreenCubeCount.ShouldBe(3);
        secondGame.RedCubeCount.ShouldBe(6);

        thirdGame.GreenCubeCount.ShouldBe(3);
        thirdGame.BlueCubeCount.ShouldBe(15);
        thirdGame.RedCubeCount.ShouldBe(14);
    }

    [Fact]
    public void GivenFifthGame_ShouldTellGameNumber()
    {
        var game = new CubeGame("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

        Assert.Equal(5, game.GameNumber);
        Assert.Equal(2, game.GamePlays.Count);

        var firstGame = game.GamePlays[0];
        var secondGame = game.GamePlays[1];

        firstGame.BlueCubeCount.ShouldBe(1);
        firstGame.GreenCubeCount.ShouldBe(3);
        firstGame.RedCubeCount.ShouldBe(6);

        secondGame.BlueCubeCount.ShouldBe(2);
        secondGame.RedCubeCount.ShouldBe(1);
        secondGame.GreenCubeCount.ShouldBe(2);
    }

    [Fact]
    public void Given11thGame_ShouldTellGameNumber()
    {
        var game = new CubeGame("Game 11: 6 red; 12 blue; 100 blue; 10000 red");

        Assert.Equal(11, game.GameNumber);
        Assert.Equal(4, game.GamePlays.Count);

        var firstGame = game.GamePlays[0];
        var secondGame = game.GamePlays[1];
        var thirdGame = game.GamePlays[2];
        var fourthGame = game.GamePlays[3];

        firstGame.RedCubeCount.ShouldBe(6);

        secondGame.BlueCubeCount.ShouldBe(12);

        thirdGame.BlueCubeCount.ShouldBe(100);

        fourthGame.RedCubeCount.ShouldBe(10000);
    }

    [Fact]
    public void Given111thGame_ShouldTellGameNumber()
    {
        var game = new CubeGame("Game 111: 6 red; 12 blue; 100 blue; 10000 red");

        Assert.Equal(111, game.GameNumber);
        Assert.Equal(4, game.GamePlays.Count);

        var firstGame = game.GamePlays[0];
        var secondGame = game.GamePlays[1];
        var thirdGame = game.GamePlays[2];
        var fourthGame = game.GamePlays[3];

        firstGame.RedCubeCount.ShouldBe(6);

        secondGame.BlueCubeCount.ShouldBe(12);

        thirdGame.BlueCubeCount.ShouldBe(100);

        fourthGame.RedCubeCount.ShouldBe(10000);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    public void GivenGameAndMaximumLimits_ShouldReturnIfPossible(string input, bool isPossible)
    {
        var game = new CubeGame(input);

        var possible = game.IsPossible(12, 13, 14);

        possible.ShouldBe(isPossible);
    }

    [Fact]
    public void GivenAllGames_ShouldReturnSumOfAllPossibleGames()
    {
        var totalOfPossibleGames = CubeGameService.TotalOfPossibleGames(
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

        totalOfPossibleGames.ShouldBe(8);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
    [InlineData("Game 5: 6 red, 1 blue; 2 blue, 1 red", 0)]
    public void GivenGame_ShouldReturnPowerOfMinimumLimit(string input, int expectedPower)
    {
        var game = new CubeGame(input);

        var power = game.PowerOfMinimumCubes();

        power.ShouldBe(expectedPower);
    }

    [Fact]
    public void GivenAllGames_ShouldReturnSumOfAllPowerOfMinimum()
    {
        var totalOfPossibleGames = CubeGameService.TotalOfAllPowerOfMinimumGames(
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

        totalOfPossibleGames.ShouldBe(2286);
    }


}