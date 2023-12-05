using System;
using System.Collections.Generic;
using System.Linq;
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

                        partNumbers.Add(new (partNumber, hasAdjacentSymbol));
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


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }

        private bool IsSymbol(char symbol)
        {
            if (symbol != '.' && !char.IsDigit(symbol))
            {
                return true;
            }

            return false;
        }
    }
}
