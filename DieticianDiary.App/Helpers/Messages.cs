using DieticianDiary.App.Concrete;

namespace DieticianDiary.App.Helpers
{
    public class Messages
    {
        public static void Positive(string information)
        {
            Underscore(information);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(information.ToUpper());
            Underscore(information);
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void Negative(string information)
        {
            Underscore(information);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(information.ToUpper());
            Underscore(information);
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void Notice(string information)
        {
            Underscore(information);
            Console.WriteLine(information);
            Underscore(information);
            Console.WriteLine();
        }
        public static void Underscore(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < name.Length; i++)
                Console.Write("-");
            Console.ResetColor();
        }
    }
}
