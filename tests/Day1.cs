using adventofcode2023;
using adventofcode2023._1;
using Xunit;

namespace tests
{
    public class Day1
    {
        [InlineData("1abc2", 12)]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("treb7uchet", 77)]
        [InlineData("two1nine", 29)]
        [InlineData("eightwothree", 83)]
        [InlineData("abcone2threexyz", 13)]
        [InlineData("xtwone3four", 24)]
        [InlineData("4nineeightseven2", 42)]
        [InlineData("zoneight234", 14)]
        [InlineData("7pqrstsixteen", 76)]
        [InlineData("threetwoonez1gtrd", 31)]
        [InlineData("two6vqgpzvmhlhfourklvxvhmnlqnmrhknstwo", 22)]
        [Theory]
        public void CalibrationService_GivenLine_FindsOutput(string value, int expected)
        {
            var valueForLine = CalibrationService.GetValueForLine(value);

            Assert.Equal(expected, valueForLine);
        }

        [Fact]
        public void CalibrationService_GivenAllText_ReturnsSum()
        {
            var value = "1abc2\r\npqr3stu8vwx\r\na1b2c3d4e5f\r\ntreb7uchet";
            var result = CalibrationService.GetValueForAllLines(value);

            Assert.Equal(142, result);
        }

        [Fact]
        public void CalibrationService_GivenAllText_ReturnsSum2()
        {
            var value = "two1nine\r\neightwothree\r\nabcone2threexyz\r\nxtwone3four\r\n4nineeightseven2\r\nzoneight234\r\n7pqrstsixteen";
            var result = CalibrationService.GetValueForAllLines(value);

            Assert.Equal(281, result);
        }

    }
}
