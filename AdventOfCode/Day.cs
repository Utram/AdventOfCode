namespace AdventOfCode
{
    internal abstract class Day
    {
        private int _number;

        private string[] _input;

        public Day(int number)
        {
            _number = number;

            // Input Data: https://adventofcode.com/2022/day/{_number}/input
            if (File.Exists($"./Input/Day{_number}.txt"))
            {
                _input = File.ReadAllLines($"./Input/Day{_number}.txt");
            } else
            {
                _input = new string[0];
            }
        }

        public virtual void Execute()
        {
            Console.WriteLine($"============== Running Code for Day{_number} ==============");
            Console.WriteLine();

            RunLogic(_input);

            Console.WriteLine();
            Console.WriteLine($"============== End of Code for Day{_number} ===============");
            Console.WriteLine();
        }

        protected abstract void RunLogic(string[] input);
    }
}