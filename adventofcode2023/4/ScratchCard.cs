namespace adventofcode2023._4;

public class ScratchCardService
{
    public ScratchCardService(string input)
    {
        var scratchCardInputs = input.Split(Environment.NewLine);
        Total = 0;
        foreach (var scratchCardInput in scratchCardInputs)
        {
            var scratchCard = new ScratchCard(scratchCardInput);
            ScratchCards.Add(scratchCard.CardNumber, new List<ScratchCard>{scratchCard});
            Total += scratchCard.Points;
        }

        foreach (var scratchCardList in ScratchCards.Values)
        {
            foreach (var scratchCard in scratchCardList
                         .Where(scratchCard => scratchCard.PlayedWinningNumbers.Count != 0))
            {
                for (var i = 1; i <= scratchCard.PlayedWinningNumbers.Count; i++)
                {
                    var cardNumber = scratchCard.CardNumber + i;
                    if (!ScratchCards.ContainsKey(cardNumber))
                        continue;

                    ScratchCards[cardNumber].Add(ScratchCards[cardNumber][0]);
                }
            }
        }

        TotalNumberOfScratchCards = ScratchCards.Sum(x => x.Value.Count);

    }

    public Dictionary<int, List<ScratchCard>> ScratchCards { get; set; } = new();

    public int Total { get; set;}
    public int TotalNumberOfScratchCards { get; set; }
}

public class ScratchCard
{
    public ScratchCard(string input)
    {
        CardNumber = int.Parse(input.Substring(4, input.IndexOf(':') - 4));

        ParseWinningNumbers(input);
        ParsePlayedNumbers(input);
        ParseWinningPlayedNumbers();
    }

    private void ParseWinningPlayedNumbers()
    {
        PlayedWinningNumbers = new List<int>();
        Points = 0;
        foreach (var number in PlayedNumbers
                     .Where(playedNumber => WinningNumbers.Contains(playedNumber)))
        {
            PlayedWinningNumbers.Add(number);
            if(Points == 0)
                Points = 1;
            else
                Points *= 2;
        }
    }

    private void ParseWinningNumbers(string input)
    {
        WinningNumbers = new List<int>();
        var stringAfterCardText = input[(input.IndexOf(':') + 2)..];
        var winningNumbersSection = stringAfterCardText.Split('|')[0];
        var listOfNumbersSplitBySpace = winningNumbersSection.Split(' ');

        foreach (var item in listOfNumbersSplitBySpace)
        {
            if (int.TryParse(item, out var number))
                WinningNumbers.Add(number);
        }
    }
    private void ParsePlayedNumbers(string input)
    {
        PlayedNumbers = new List<int>();
        var listOfNumbersSplitBySpace = input[(input.IndexOf('|') + 2)..]
            .Split(' ');

        foreach (var item in listOfNumbersSplitBySpace)
        {
            if (int.TryParse(item, out var number))
                PlayedNumbers.Add(number);
        }
    }

    public int CardNumber { get; set; }
    public List<int> WinningNumbers { get; set; }
    public List<int> PlayedNumbers { get; set; }
    public List<int> PlayedWinningNumbers { get; set; }

    public int Points { get; set; }
}