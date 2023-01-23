using DieticianDiary.App.Concrete;

namespace DieticianDiary.App.Helpers
{
    public class Messages
    {
        public static void Positive(string message)
        {
            Underscore(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message.ToUpper());
            Underscore(message);
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void Negative(string message)
        {
            Underscore(message);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message.ToUpper());
            Underscore(message);
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void Notice(string message)
        {
            Underscore(message);
            Console.WriteLine(message);
            Underscore(message);
            Console.WriteLine();
        }

        public static void Underscore(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < name.Length; i++)
                Console.Write("-");
            Console.ResetColor();
        }

        public static ConsoleKeyInfo Choice()
        {
            string message = "Your choice: ";
            Underscore(message);
            Console.Write("\nYour choice: ");
            var choice = Console.ReadKey();
            Console.WriteLine();
            return choice;
        }
    }
}
