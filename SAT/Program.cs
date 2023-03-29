namespace SAT
{
    public class Program
    {
        public static void Main()
        {
            SAT.Start("c A sample .cnf file.\np cnf 2 4\n1 2 0\n1 -2 0\n-1 -2 0\n-1 2 0");
        }
    }
}