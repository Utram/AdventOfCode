using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode.Y2023
{
    // https://adventofcode.com/2023/day/3
    internal class Day3 : Day
    {
        public Day3() : base(2023, 3)
        {
        }

        protected override void RunLogic(string[] input)
        {
            // Part 1

            Console.WriteLine(); 
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Part 1");
            Console.WriteLine();

            // Initialize Baord
            char[,] board = new char[140,140];

            for (int row = 0; row < 140; row++)
            {
                for (int column = 0; column < 140; column++)
                {
                    board[row, column] = input[row][column];
                }
            }

            var partNumbers = new List<(int PartNumber, bool HasAdjacentSymbol)>();

            // Scan for possible part number
            for (int row = 0; row < 140; row++)
            {
                var hasAdjacentSymbol = false;
                var partDigits = new List<char>();

                for (int column = 0; column < 140; column++)
                {
                    if (char.IsDigit(board[row,column]))
                    {
                        partDigits.Add(board[row, column]);

                        // Check if adjacent to a symbol
                        if (column > 0   && IsSymbol(board[row, column - 1]) ||
                            column < 139 && IsSymbol(board[row, column + 1]) ||
                            row > 0      && IsSymbol(board[row - 1, column]) ||
                            row < 139 && IsSymbol(board[row + 1, column]) ||
                            row < 139 && column < 139 && IsSymbol(board[row + 1, column + 1]) ||
                            row > 0   && column > 0   && IsSymbol(board[row - 1, column - 1]) ||
                            row < 139 && column > 0   && IsSymbol(board[row + 1, column - 1]) ||
                            row > 0   && column < 139 && IsSymbol(board[row - 1, column + 1]))
                        {
                            hasAdjacentSymbol = true;
                        }

                        if (row <= 139 && column < 139)
                        {
                            continue;
                        }
                    }

                    if (partDigits.Count > 0)
                    {
                        var partNumberString = string.Join("", partDigits.ToArray());
                        var partNumber = int.Parse(partNumberString);

                        partNumbers.Add((partNumber, hasAdjacentSymbol));
                        partDigits.Clear();
                        hasAdjacentSymbol = false;
                    }
                }
            }

            var sumOfPartsWithAdjacentSymbols = partNumbers.Where(x => x.HasAdjacentSymbol)
                                                           .Sum(x => x.PartNumber);
            
            Console.WriteLine();
            Console.WriteLine($"Sum of parts with adjacent symbols: {sumOfPartsWithAdjacentSymbols}");
            Console.WriteLine();

            // Part 2

            Console.WriteLine();
            Console.WriteLine("Part 2");
            Console.WriteLine();

            var gearCoordinates = new List<(int Row, int Column)>();

            for (int row = 0; row < 140; row++)
            {
                for (int column = 0; column < 140; column++)
                {
                    if (IsGear(board[row, column]))
                    {
                        gearCoordinates.Add((row, column));
                    }
                }
            }

            var coordinatesWithExactlyTwoAdjacentPartNumbers = new List<(int Row, int Column, List<int> PartNumbers)>();

            foreach (var coordinate in gearCoordinates)
            {
                var adjacentPartNumbersCount = 0;

                // Check Top Row
                if (coordinate.Row > 0 && char.IsDigit(board[coordinate.Row - 1, coordinate.Column])     ||
                    coordinate.Row > 0 && char.IsDigit(board[coordinate.Row - 1, coordinate.Column + 1]) ||
                    coordinate.Row > 0 && char.IsDigit(board[coordinate.Row - 1, coordinate.Column - 1]))
                {
                    adjacentPartNumbersCount++;
                }
                // Check Bottom Row
                if (coordinate.Row < 139 && char.IsDigit(board[coordinate.Row + 1, coordinate.Column]) ||
                    coordinate.Row < 139 && char.IsDigit(board[coordinate.Row + 1, coordinate.Column + 1]) ||
                    coordinate.Row < 139 && char.IsDigit(board[coordinate.Row + 1, coordinate.Column - 1]))
                {
                    adjacentPartNumbersCount++;
                }
                // Check Left
                if (coordinate.Column > 0   && char.IsDigit(board[coordinate.Row, coordinate.Column - 1]))
                {
                    adjacentPartNumbersCount++;
                }
                // Check Right
                if (coordinate.Column < 139 && char.IsDigit(board[coordinate.Row, coordinate.Column + 1]))
                {
                    adjacentPartNumbersCount++;
                }

                if (adjacentPartNumbersCount == 2)
                {
                    coordinatesWithExactlyTwoAdjacentPartNumbers.Add((coordinate.Row, coordinate.Column, new List<int>()));
                }
            }

            var digits = new List<char>();
            var partNumbers2 = new List<int>();

            foreach (var coordinate in coordinatesWithExactlyTwoAdjacentPartNumbers)
            {
                var index = 1;

                // Above
                if ((coordinate.Row > 0) && char.IsDigit(board[coordinate.Row - 1, coordinate.Column]))
                {
                    digits.Add(board[coordinate.Row - 1, coordinate.Column]);

                    while ((coordinate.Column - index) >= 0 && char.IsDigit(board[coordinate.Row - 1, coordinate.Column - index]))
                    {
                        digits.Insert(0, board[coordinate.Row - 1, coordinate.Column - index]);
                        index++;
                    }

                    index = 1;

                    while ((coordinate.Column + index) <= 139 && char.IsDigit(board[coordinate.Row - 1, coordinate.Column + index]))
                    {
                        digits.Add(board[coordinate.Row - 1, coordinate.Column + index]);
                        index++;
                    }

                    index = 1;

                    CombineDigitsAndAddToCoordinate(digits, partNumbers2, coordinate);
                }
                else if (char.IsDigit(board[coordinate.Row - 1, coordinate.Column + 1]))
                {
                    while ((coordinate.Column + index) <= 139 && char.IsDigit(board[coordinate.Row - 1, coordinate.Column + index]))
                    {
                        digits.Add(board[coordinate.Row - 1, coordinate.Column + index]);
                        index++;
                    }

                    index = 1;
                    CombineDigitsAndAddToCoordinate(digits, partNumbers2, coordinate);
                }
                else if (char.IsDigit(board[coordinate.Row - 1, coordinate.Column - 1]))
                {
                    while ((coordinate.Column - index) >= 0 && char.IsDigit(board[coordinate.Row - 1, coordinate.Column - index]))
                    {
                        digits.Insert(0, board[coordinate.Row - 1, coordinate.Column - index]);
                        index++;
                    }

                    index = 1;
                    CombineDigitsAndAddToCoordinate(digits, partNumbers2, coordinate);
                }

                // Below
                if ((coordinate.Row < 139) && char.IsDigit(board[coordinate.Row + 1, coordinate.Column]))
                {
                    digits.Add(board[coordinate.Row + 1, coordinate.Column]);

                    while ((coordinate.Column - index) >= 0 && char.IsDigit(board[coordinate.Row + 1, coordinate.Column - index]))
                    {
                        digits.Insert(0, board[coordinate.Row + 1, coordinate.Column - index]);
                        index++;
                    }

                    index = 1;

                    while ((coordinate.Column + index) <= 139 && char.IsDigit(board[coordinate.Row + 1, coordinate.Column + index]))
                    {
                        digits.Add(board[coordinate.Row + 1, coordinate.Column + index]);
                        index++;
                    }

                    index = 1;
                    CombineDigitsAndAddToCoordinate(digits, partNumbers2, coordinate);
                }
                else if (char.IsDigit(board[coordinate.Row + 1, coordinate.Column + 1]))
                {
                    while ((coordinate.Column + index) <= 139 && char.IsDigit(board[coordinate.Row + 1, coordinate.Column + index]))
                    {
                        digits.Add(board[coordinate.Row + 1, coordinate.Column + index]);
                        index++;
                    }

                    index = 1;
                    CombineDigitsAndAddToCoordinate(digits, partNumbers2, coordinate);
                } 
                else if (char.IsDigit(board[coordinate.Row + 1, coordinate.Column - 1]))
                {
                    while ((coordinate.Column - index) >= 0 && char.IsDigit(board[coordinate.Row + 1, coordinate.Column - index]))
                    {
                        digits.Insert(0, board[coordinate.Row + 1, coordinate.Column - index]);
                        index++;
                    }

                    index = 1;
                    CombineDigitsAndAddToCoordinate(digits, partNumbers2, coordinate);
                }

                // Right
                if (coordinate.Column < 139 && char.IsDigit(board[coordinate.Row, coordinate.Column + 1]))
                {
                    while ((coordinate.Column + index) <= 139 && char.IsDigit(board[coordinate.Row, coordinate.Column + index]))
                    {
                        digits.Add(board[coordinate.Row, coordinate.Column + index]);
                        index++;
                    }

                    index = 1;
                    CombineDigitsAndAddToCoordinate(digits, partNumbers2, coordinate);
                }

                // Left
                if (coordinate.Column > 0 && char.IsDigit(board[coordinate.Row, coordinate.Column - 1]))
                {
                    while ((coordinate.Column - index) >= 0 && char.IsDigit(board[coordinate.Row, coordinate.Column - index]))
                    {
                        digits.Insert(0, board[coordinate.Row, coordinate.Column - index]);
                        index++;
                    }

                    index = 1;
                    CombineDigitsAndAddToCoordinate(digits, partNumbers2, coordinate);
                }
            }

            var resultSet = coordinatesWithExactlyTwoAdjacentPartNumbers.Select(x => new 
            {
                Row = x.Row,
                Column = x.Column,
                PartNumbers = x.PartNumbers,
                // Multiplizieren aller Enthaltener Teilenummern per Aggregate
                GearRatio = x.PartNumbers.Aggregate((y,z) => y * z)
            });

            var sumOfAllGearRatios = resultSet.Sum(x => x.GearRatio);

            Console.WriteLine();
            Console.WriteLine($"Sum of all gear ratios: {sumOfAllGearRatios}");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }

        private void CombineDigitsAndAddToCoordinate(List<char> digits, List<int> partNumbers, (int Row, int Column, List<int> PartNumbers) coordinate)
        {
            if (digits.Count > 0)
            {
                var partNumberString = string.Join("", digits.ToArray());
                var partNumber = int.Parse(partNumberString);
                partNumbers.Add(partNumber);
                coordinate.PartNumbers.Add(partNumber);
                digits.Clear();
            }
        }

        private bool IsSymbol(char symbol)
        {
            return symbol != '.' && !char.IsDigit(symbol);
        }

        private bool IsGear(char symbol)
        {
            return symbol == '*';
        }
    }
}
