namespace AdventOfCode
{
    internal abstract class Day
    {
        private int _day;
        private int _year;

        private string[] _input;

        public Day(int year, int day)
        {
            _day = day;
            _year = year;

            // Input Data: https://adventofcode.com/{_year}/day/{_day}/input
            if (File.Exists($"./{_year}/Input/Day{_day}.txt"))
            {
                _input = File.ReadAllLines($"./{_year}/Input/Day{_day}.txt");
            }
            else
            {
                _input = new string[0];
            }
        }

        public virtual void Execute()
        {
            Console.WriteLine($"============== Running Code for Day{_day} ==============");
            Console.WriteLine();

            RunLogic(_input);

            Console.WriteLine();
            Console.WriteLine($"============== End of Code for Day{_day} ===============");
            Console.WriteLine();
        }

        protected abstract void RunLogic(string[] input);
    }
}