// See https://aka.ms/new-console-template for more information

using adventofcode2023;
using adventofcode2023._4;


//Day 1
//CalibrationService.GenerateOutput(File.ReadAllText("input.txt"));
//Console.WriteLine(CalibrationService.GetValueForAllLines(File.ReadAllText("input.txt")));

//Day 2
//var totalOfPossibleGames= CubeGameService.TotalOfAllPowerOfMinimumGames(File.ReadAllText("input.txt"));
//Console.WriteLine(totalOfPossibleGames);

//Day 3
//var manual = new Manual(File.ReadAllText("input.txt"));
//Console.WriteLine(manual.TotalGearRatio);
//manual.WriteCharacters();


//Day 4
var scratchCardService = new ScratchCardService(File.ReadAllText("input.txt"));
Console.WriteLine(scratchCardService.TotalNumberOfScratchCards);