using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Y2023
{
    // https://adventofcode.com/2023/day/1
    internal class Day1 : Day
    {
        public Day1() : base(2023, 1)
        {
        }

        protected override void RunLogic(string[] input)
        {
            var calibrationValues = new List<int>();

            foreach (var line in input)
            {
                var digits = Regex.Matches(line, "\\d", RegexOptions.IgnoreCase);

                if (digits.Count > 0)
                {
                    var firstDigit = digits.First().Value;
                    var lastDigit  = digits.Last().Value;

                    var calibrationValue = int.Parse(firstDigit + lastDigit);

                    calibrationValues.Add(calibrationValue);
                }
            }

            var sumOfAllCalibrationValues = calibrationValues.Sum();

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Sum of all Calibration Values: {sumOfAllCalibrationValues}");
            Console.WriteLine();
        }
    }
}
