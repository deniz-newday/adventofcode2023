using System.Security.Cryptography.X509Certificates;
using adventofcode2023._4;
using Shouldly;
using Xunit;

namespace tests;

public class Day4
{
    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 1)]
    [InlineData("Card 12: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 12)]
    [InlineData("Card 124: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 124)]
    public void GivenCardInput_ShouldTellCardNumber(string input, int expected)
    {
        var scratchCard = new ScratchCard(input);
        scratchCard.CardNumber.ShouldBe(expected);
    }

    [Fact]
    public void GivenInput_ScratchCardShouldKnowWinningNumbers()
    {
        var scratchCard = new ScratchCard("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");
        scratchCard.WinningNumbers.Count().ShouldBe(5);
        scratchCard.WinningNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 41, 48, 83, 86, 17 });
        scratchCard.PlayedNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 83 ,86  ,6 ,31 ,17  ,9 ,48 ,53 });
        scratchCard.Points.ShouldBe(8);
    }
    [Fact]
    public void GivenInput_ScratchCardShouldKnowWinningNumbers2()
    {
        var scratchCard = new ScratchCard("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19");
        scratchCard.WinningNumbers.Count().ShouldBe(5);
        scratchCard.WinningNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 13 ,32, 20, 16, 61 });
        scratchCard.PlayedNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 61 ,30 ,68 ,82 ,17 ,32 ,24 ,19 });
        scratchCard.Points.ShouldBe(2);
    }
    [Fact]
    public void GivenInput_ScratchCardShouldKnowWinningNumbers3()
    {
        var scratchCard = new ScratchCard("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1");
        scratchCard.WinningNumbers.Count().ShouldBe(5);
        scratchCard.WinningNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 1 ,21 ,53, 59, 44 });
        scratchCard.PlayedNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 69 ,82 ,63 ,72 ,16 ,21 ,14  ,1 });
        scratchCard.Points.ShouldBe(2);

    }
    [Fact]
    public void GivenInput_ScratchCardShouldKnowWinningNumbers4()
    {
        var scratchCard = new ScratchCard("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83");
        scratchCard.WinningNumbers.Count().ShouldBe(5);
        scratchCard.WinningNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 41 ,92, 73, 84, 69 });
        scratchCard.PlayedNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 59 ,84 ,76 ,51 ,58  ,5 ,54 ,83 });
        scratchCard.Points.ShouldBe(1);

    }
    [Fact]
    public void GivenInput_ScratchCardShouldKnowWinningNumbers5()
    {
        var scratchCard = new ScratchCard("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36");
        scratchCard.WinningNumbers.Count().ShouldBe(5);
        scratchCard.WinningNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 87 ,83 ,26 ,28 ,32 });
        scratchCard.PlayedNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 88, 30, 70, 12, 93, 22, 82, 36 });
        scratchCard.Points.ShouldBe(0);
    }

    [Fact]
    public void GivenInput_ScratchCardShouldKnowWinningNumbers6()
    {
        var scratchCard = new ScratchCard("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11");
        scratchCard.WinningNumbers.Count().ShouldBe(5);
        scratchCard.WinningNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 31 ,18 ,13 ,56 ,72 });
        scratchCard.PlayedNumbers.ToArray().ShouldBeEquivalentTo(new[]{ 74 ,77 ,10 ,23 ,35 ,67 ,36 ,11 });
        scratchCard.Points.ShouldBe(0);
    }

    [Fact]
    public void ScratchCardService_ShouldReturnTotal()
    {
        var sc = new ScratchCardService(
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\r\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\r\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\r\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\r\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\r\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11");
        sc.Total.ShouldBe(13);
    }

    [Fact]
    public void GivenFirstScratchCardHas2WinningPlayedNumbers_ShouldDoubleNext2ScratchCards()
    {
        var sc = new ScratchCardService(
            "Card 1: 41 48 83 86 17 | 83 86  6 31 10  9 49 53\r\nCard 2: 13 32 20 16 61 | 1 2 3 4 5 7 9 8\r\nCard 3:  1 21 53 59 44 | 2 3 4 5 6 7 8  9");

        sc.ScratchCards[2].Count.ShouldBe(2);
        sc.ScratchCards[3].Count.ShouldBe(2);
    }

    [Fact]
    public void GivenTestInput_ShouldIncreaseNumberOfScratchCardsAccordingly()
    {
        var sc = new ScratchCardService(
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\r\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\r\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\r\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\r\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\r\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11");

        sc.ScratchCards[1].Count.ShouldBe(1);
        sc.ScratchCards[2].Count.ShouldBe(2);
        sc.ScratchCards[3].Count.ShouldBe(4);
        sc.ScratchCards[4].Count.ShouldBe(8);
        sc.ScratchCards[5].Count.ShouldBe(14);
        sc.ScratchCards[6].Count.ShouldBe(1);

        sc.TotalNumberOfScratchCards.ShouldBeEquivalentTo(30);
    }

}