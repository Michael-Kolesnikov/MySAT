namespace MySAT
{
    public class Program
    {
        public static void Main()
        {
            List<List<int>> clauses = new()
            {
            new List<int> { -1, -2, 3 },
            new List<int> { 2, 3 },
            new List<int> { 9, 2, -3 },
            new List<int> { -1, 2, -6 },
            new List<int> { 7, 2, 3 },
            new List<int> { -1, 4, -5 },
            new List<int> { -1, 2, 3 },
            new List<int> { -1, 2, 6 },
            new List<int> { 1, 5, 3 },
            };
        }
    }
}