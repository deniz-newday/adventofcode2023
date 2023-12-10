using adventofcode2023;
using adventofcode2023._3;
using Shouldly;
using Xunit;

namespace tests;

public class Day3
{
    [Fact]
    public void Manual_ShouldReturnAllCharacterLocations()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        manual.SymbolLocations.Count.ShouldBe(6);
    }

    [Fact]
    public void Manual_ShouldSetFirstPartNumbersAndTheirLocations()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        var partNumberLocation = manual.PartNumberLocations[0];
        partNumberLocation.Locations.Count.ShouldBe(3);
        partNumberLocation.Locations[0].X.ShouldBe(2);
        partNumberLocation.Locations[0].Y.ShouldBe(0);

        partNumberLocation.Locations[1].X.ShouldBe(1);
        partNumberLocation.Locations[1].Y.ShouldBe(0);

        partNumberLocation.Locations[2].X.ShouldBe(0);
        partNumberLocation.Locations[2].Y.ShouldBe(0);
    }

    //[Fact]
    //public void GivenBigInput_SumIsExpected()
    //{
    //    var manual  = new Manual(File.ReadAllText("input.txt"));
    //    manual.SumOfValidPartNumbers().ShouldBe(530849);
    //}
    //[Fact]
    //public void GivenBigInput_GearRaitioIsExpected()
    //{
    //    var manual  = new Manual(File.ReadAllText("input.txt"));
    //    manual.TotalGearRatio.ShouldBe(530849);
    //}

    [Fact]
    public void Manual_ShouldSetSecondPartNumbersAndTheirLocations()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        var partNumberLocation = manual.PartNumberLocations[1];
        partNumberLocation.Locations.Count.ShouldBe(3);

        partNumberLocation.Locations[0].X.ShouldBe(7);
        partNumberLocation.Locations[0].Y.ShouldBe(0);

        partNumberLocation.Locations[1].X.ShouldBe(6);
        partNumberLocation.Locations[1].Y.ShouldBe(0);

        partNumberLocation.Locations[2].X.ShouldBe(5);
        partNumberLocation.Locations[2].Y.ShouldBe(0);
    }

    [Fact]
    public void Manual_ShouldSetThirdPartNumbersAndTheirLocations()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        var partNumberLocation = manual.PartNumberLocations[2];
        partNumberLocation.Locations.Count.ShouldBe(2);

        partNumberLocation.Locations[0].X.ShouldBe(3);
        partNumberLocation.Locations[0].Y.ShouldBe(2);

        partNumberLocation.Locations[1].X.ShouldBe(2);
        partNumberLocation.Locations[1].Y.ShouldBe(2);
    }

    [Fact]
    public void Manual_ShouldSetIfPartNumberIsValidByCheckingIfItIsNextToASymbol()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        manual.ValidPartNumbers.Count.ShouldBe(8);
        manual.ValidPartNumbers.Select(x => x.PartNumber).ToArray().ShouldBeEquivalentTo(new[] { 35, 467, 633, 617, 592, 664, 598, 755 });

    }
    
    [Fact]
    public void Manual_ShouldReturnSumOfValidPartNumbers()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        manual.SumOfValidPartNumbers().ShouldBe(4361);
    }

    [Fact]
    public void Manual_CanFindGearSymbols()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        manual.GearSymbols.Count.ShouldBe(3);
        manual.GearSymbols[0].Location.X.ShouldBe(3);
        manual.GearSymbols[0].Location.Y.ShouldBe(1);

        manual.GearSymbols[1].Location.X.ShouldBe(3);
        manual.GearSymbols[1].Location.Y.ShouldBe(4);
            
        manual.GearSymbols[2].Location.X.ShouldBe(5);
        manual.GearSymbols[2].Location.Y.ShouldBe(8);
    }

    [Fact]
    public void Manual_CanFindGearSymbolsNextTo2PartNumbers()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        manual.GearSymbols.Count(x => x.IsGear).ShouldBe(2);
    }
    [Fact]
    public void Manual_CanFindGearSymbolsNextTo2PartNumbersPart2()
    {
        var manual =
            new Manual(
                "........512\r\n289.33*....\r\n.*.....713.\r\n..439......");

        var locationsToCheck = manual.PartNumberLocations.First(x => x.PartNumber == 512).Locations;
        locationsToCheck.ShouldContain(x => x.X == 8 && x.Y ==0);
        locationsToCheck.ShouldContain(x => x.X == 9 && x.Y ==0);
        locationsToCheck.ShouldContain(x => x.X == 10 && x.Y ==0);
        
        manual.GearSymbols.Count(x => x.IsGear).ShouldBe(2);
    }
    [Fact]
    public void Manual_CanFindTotalGearRatio()
    {
        var manual =
            new Manual(
                "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..");

        manual.TotalGearRatio.ShouldBe(467835);
    }
}