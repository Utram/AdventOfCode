namespace AdventOfCode
{
    // https://adventofcode.com/2022/day/8
    internal class Day8 : Day
    {
        public Day8() : base(8)
        {
        }

        private const int xMax = 99;
        private const int yMax = 99;

        private int[,] _forestHeights = new int[xMax, yMax];
        private int[,] _forestScenicScoring = new int[xMax, yMax];
        private bool[,] _forestVisibility = new bool[xMax, yMax];

        protected override void RunLogic(string[] input)
        {
            var xMax = input.Length;
            var yMax = input[0].Length;

            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    _forestHeights[x, y] = input[y][x] % 48;
                    _forestVisibility[x, y] = false;
                    _forestScenicScoring[x, y] = 0;
                }
            }

            for (int x = 0; x < xMax; x++)
            {
                for (int y = 0; y < yMax; y++)
                {
                    _forestVisibility[x, y] = IsEdgePosition(x, y) || IsVisible(x, y);
                    _forestScenicScoring[x, y] = CalculateScenicScore(x, y);
                }
            }

            // Part 1
            var visibleTrees = _forestVisibility.Cast<bool>()
                                                .Where(isVisible => isVisible)
                                                .Count();

            Console.WriteLine($"Visible Trees: {visibleTrees}");

            // Part 2
            var highestScenicScore = _forestScenicScoring.Cast<int>()
                                                         .Max();

            Console.WriteLine($"Highest Scenic Score: {highestScenicScore}");
        }

        // Checks if the tree is on a edge position and therefore visible
        private bool IsEdgePosition(int x, int y)
        {
            if (x == 0 || x == xMax || y == 0 || y == yMax)
            {
                return true;
            }

            return false;
        }

        // Checks if the tree is visible to any side
        private bool IsVisible(int x, int y)
        {
            var treeHeight = _forestHeights[x, y];

            // Expect general visibility
            var visibilityRight = true;
            var visibilityLeft = true;
            var visibilityTop = true;
            var visibilityBottom = true;

            // To the right
            for (int i = x + 1; i < xMax; i++)
            {
                if (treeHeight <= _forestHeights[i, y])
                {
                    visibilityRight = false;
                    break;
                }
            }

            // To the left
            for (int i = x - 1; i >= 0; i--)
            {
                if (treeHeight <= _forestHeights[i, y])
                {
                    visibilityLeft = false;
                    break;
                }
            }

            // To the top
            for (int i = y + 1; i < yMax; i++)
            {
                if (treeHeight <= _forestHeights[x, i])
                {
                    visibilityTop = false;
                    break;
                }
            }

            // To the bottom
            for (int i = y - 1; i >= 0; i--)
            {
                if (treeHeight <= _forestHeights[x, i])
                {
                    visibilityBottom = false;
                    break;
                }
            }

            return visibilityTop || visibilityBottom || visibilityRight || visibilityLeft;
        }

        // TODO: METHODE KORRIGIEREN!
        // Checks the viewing range for each side and calculates the resulting score
        private int CalculateScenicScore(int x, int y)
        {
            var treeHeight = _forestHeights[x, y];

            var viewRangeRight = 0;
            var viewRangeLeft = 0;
            var viewRangeTop = 0;
            var viewRangeBottom = 0;

            // To the right
            for (int i = x; i < xMax; i++)
            {
                if (x == xMax || i != x && treeHeight <= _forestHeights[i, y])
                {
                    //viewRangeRight = i - x; // End - Start
                    break;
                } else
                {
                    viewRangeRight++;
                }
            }

            // To the left
            for (int i = x; i >= 0; i--)
            {
                if (x == 0 || i != x && treeHeight <= _forestHeights[i, y])
                {
                    //viewRangeLeft = x - i; // Start - End
                    break;
                } else
                {
                    viewRangeLeft++;
                }
            }

            // To the top
            for (int i = y; i < yMax; i++)
            {
                if (y == 0 || i != y && treeHeight <= _forestHeights[x, i])
                {
                    //viewRangeTop = i - y; // End - Start
                    break;
                }
                else
                {
                    viewRangeTop++;
                }
            }

            // To the bottom
            for (int i = y; i >= 0; i--)
            {
                if (y == yMax || i != y && treeHeight <= _forestHeights[x, i])
                {
                    //viewRangeBottom = y - i; // Start - End
                    break;
                } else
                {
                    viewRangeBottom++;
                }
            }

            return viewRangeRight * viewRangeLeft * viewRangeTop * viewRangeBottom;
        }
    }
}