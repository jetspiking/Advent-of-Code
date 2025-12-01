namespace AOC_1
{
    internal class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine(CountZeroHits(50));
            Console.WriteLine(Count0x434C49434B(50));
        }

        public static Int32 CountZeroHits(Int32 start)
        {
            String path = Path.Combine(AppContext.BaseDirectory, "input");

            Int32 current = start;
            Int32 zeroCount = 0;

            foreach (String line in File.ReadLines(path))
            {
                Char direction = line[0];
                Int32 distance = Int32.Parse(line[1..]);

                if (direction == 'R')
                    current = (current + distance) % 100;
                else
                    current = (current - distance + 100) % 100;

                if (current == 0) zeroCount++;
            }

            return zeroCount;
        }

        public static Int32 Count0x434C49434B(Int32 start)
        {
            String path = Path.Combine(AppContext.BaseDirectory, "input");

            Int32 current = start;
            Int32 zeroCount = 0;

            foreach (String line in File.ReadLines(path))
            {
                Char direction = line[0];
                Int32 distance = Int32.Parse(line[1..]);

                if (direction == 'R')
                {
                    Int32 first = (100 - current) % 100;
                    if (first == 0) first = 100;
                    zeroCount += distance >= first ? 1 + (distance - first) / 100 : 0;
                    current = (current + distance) % 100;
                }
                else
                {
                    Int32 first = current % 100;
                    if (first == 0) first = 100;
                    zeroCount += distance >= first ? 1 + (distance - first) / 100 : 0;
                    current = (current - distance) % 100;
                    if (current < 0) current += 100;
                }
            }

            return zeroCount;
        }
    }
}
