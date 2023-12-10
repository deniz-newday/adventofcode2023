using System.Text;

namespace adventofcode2023;

public class Manual
{
    public Manual(string input)
    {
        SymbolLocations = new List<Location>();
        PartNumberLocations = new List<PartNumberLocation>();
        ValidPartNumbers = new List<PartNumberLocation>();
        GearSymbols = new List<Gear>();
        SetPartNumbersAndSymbols(input);
        ValidatePartNumbers();

        SetGears(input);
        TotalGearRatio = GearSymbols.Sum(x => x.GearRatio);
    }


    private void ValidatePartNumbers()
    {
        foreach (var characterLocation in SymbolLocations)
        {
            CheckIfPartNumberIsInTheLocation(characterLocation.X, characterLocation.Y);
            CheckIfPartNumberIsInTheLocation(characterLocation.X, characterLocation.Y - 1);
            CheckIfPartNumberIsInTheLocation(characterLocation.X, characterLocation.Y + 1);
            CheckIfPartNumberIsInTheLocation(characterLocation.X - 1, characterLocation.Y);
            CheckIfPartNumberIsInTheLocation(characterLocation.X - 1, characterLocation.Y + 1);
            CheckIfPartNumberIsInTheLocation(characterLocation.X - 1, characterLocation.Y - 1);
            CheckIfPartNumberIsInTheLocation(characterLocation.X + 1, characterLocation.Y);
            CheckIfPartNumberIsInTheLocation(characterLocation.X + 1, characterLocation.Y - 1);
            CheckIfPartNumberIsInTheLocation(characterLocation.X + 1, characterLocation.Y + 1);
        }
    }

    private void CheckIfPartNumberIsInTheLocation(int x, int y)
    {
        foreach (var partNumberLocation in PartNumberLocations.Where(partNumberLocation => !partNumberLocation.AddedToTheList &&
                     partNumberLocation.OnLocation(x, y)))
        {
            partNumberLocation.AddedToTheList = true;
            ValidPartNumbers.Add(partNumberLocation);
        }
    }

    private void SetPartNumbersAndSymbols(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var previousCharacterWasDigit = false;
        var stringBuilder = new StringBuilder();
        for (var lineNumber = 0; lineNumber < input.Split(Environment.NewLine).Length; lineNumber++)
        {
            var line = lines[lineNumber];
            for (var lineCharacterIndex = 0; lineCharacterIndex < line.Length; lineCharacterIndex++)
            {
                if (IsSymbol(line[lineCharacterIndex]))
                {
                    SymbolLocations.Add(new Location(lineCharacterIndex, lineNumber));
                }

                if (char.IsDigit(line[lineCharacterIndex]))
                {
                    stringBuilder.Append(line[lineCharacterIndex]);
                    previousCharacterWasDigit = true;

                    if (lineCharacterIndex == line.Length - 1)
                    {
                        var partNumber = int.Parse(stringBuilder.ToString());
                        PartNumberLocations.Add(new PartNumberLocation(partNumber, new Location(lineCharacterIndex, lineNumber)));

                        stringBuilder.Clear();
                        previousCharacterWasDigit = false;

                    }
                }
                else if (previousCharacterWasDigit)
                {
                    var partNumber = int.Parse(stringBuilder.ToString());
                    PartNumberLocations.Add(new PartNumberLocation(partNumber, new Location(lineCharacterIndex-1, lineNumber)));

                    stringBuilder.Clear();
                    previousCharacterWasDigit = false;
                }
            }
        }
    }
    
    private void SetGears(string input)
    {
        var lines = input.Split(Environment.NewLine);
        for (var lineNumber = 0; lineNumber < input.Split(Environment.NewLine).Length; lineNumber++)
        {
            var line = lines[lineNumber];
            for (var lineCharacterIndex = 0; lineCharacterIndex < line.Length; lineCharacterIndex++)
            {
                if (IsGear(line[lineCharacterIndex]))
                {
                    GearSymbols.Add(new Gear(new Location(lineCharacterIndex, lineNumber), ValidPartNumbers));
                }
            }
        }
    }

    public readonly List<Location> SymbolLocations;
    public readonly List<PartNumberLocation> PartNumberLocations;
    public readonly List<PartNumberLocation> ValidPartNumbers;
    public int TotalGearRatio { get; set; }
    public List<Gear> GearSymbols { get; set; }

    private bool IsSymbol(char lineCharacter)
    {
        return !char.IsDigit(lineCharacter) && lineCharacter != '.';
    }

    private bool IsGear(char lineCharacter)
    {
        return lineCharacter == '*';
    }

    public int SumOfValidPartNumbers()
    {
        return ValidPartNumbers.Sum(x => x.PartNumber);
    }
}

public class PartNumberLocation
{
    public PartNumberLocation(int partNumber, Location location)
    {
        PartNumber = partNumber;
        var numberOfDigits = Math.Floor(Math.Log10(partNumber) + 1);
        
        Locations = new List<Location>();
        for (var i = 0; i < numberOfDigits; i++)
        {
            Locations.Add(new Location(location.X - i, location.Y));
        }
    }

    public List<Location> Locations;
    public int PartNumber;
    public bool AddedToTheList { get; set; }

    public bool OnLocation(int x, int y)
    {
        return Locations.Any(location => location.X == x && location.Y == y);
    }
}

public class Gear
{
    private readonly List<PartNumberLocation> _partNumberLocations;

    public Gear(Location location, List<PartNumberLocation> partNumberLocations)
    {
        _partNumberLocations = partNumberLocations;
        Location = location;

        var topLeft = partNumberLocations.Where(x => x.OnLocation(location.X - 1, location.Y - 1));
        var top = partNumberLocations.Where(x => x.OnLocation(location.X, location.Y - 1));
        var topRight = partNumberLocations.Where(x => x.OnLocation(location.X + 1, location.Y - 1));
        var left = partNumberLocations.Where(x => x.OnLocation(location.X - 1, location.Y));
        var right = partNumberLocations.Where(x => x.OnLocation(location.X + 1, location.Y));
        var bottomLeft = partNumberLocations.Where(x => x.OnLocation(location.X - 1, location.Y + 1));
        var bottom = partNumberLocations.Where(x => x.OnLocation(location.X, location.Y + 1));
        var bottomRight = partNumberLocations.Where(x => x.OnLocation(location.X + 1, location.Y + 1));

        var neighbourPartNumbers = topLeft.Concat(top).Concat(topRight).Concat(left).Concat(right).Concat(bottomLeft).Concat(bottom).Concat(bottomRight).Distinct().ToList();

        IsGear = neighbourPartNumbers.Count == 2;

        if (IsGear)
        {
            GearRatio = neighbourPartNumbers[0].PartNumber * neighbourPartNumbers[1].PartNumber;
        }
    }

    public Location Location { get; set; }

    public bool IsGear { get; set; }

    public int GearRatio { get; set; }
}
public class Location
{
    public Location(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}
