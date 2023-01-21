using DieticianDiary.App.Common;
using DieticianDiary.Domain.Entity;
using System.Globalization;
using System.Xml.Linq;

namespace DieticianDiary.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                    result.Add(menuAction);
            }
            return result;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Go to user data ", "Main"));
            AddItem(new MenuAction(2, "Go to patient database", "Main"));
            AddItem(new MenuAction(3, "Calculate BMI", "Main"));
            AddItem(new MenuAction(0, "Close application", "Main"));

            AddItem(new MenuAction(1, "Update user data", "User Data Menu"));
            AddItem(new MenuAction(0, "Back to main menu", "User Data Menu"));

            AddItem(new MenuAction(1, "First name", "Update User"));
            AddItem(new MenuAction(2, "Last name", "Update User"));
            AddItem(new MenuAction(3, "Phone number", "Update User"));
            AddItem(new MenuAction(4, "Email address", "Update User"));
            AddItem(new MenuAction(5, "Sex", "Update User"));
            AddItem(new MenuAction(6, "Specialization", "Update User"));

            AddItem(new MenuAction(0, "Close application", "PatientDatabaseMenu"));
            AddItem(new MenuAction(1, "Add patient", "PatientDatabaseMenu"));
            AddItem(new MenuAction(2, "Show patient", "PatientDatabaseMenu"));
            AddItem(new MenuAction(3, "Show all patients", "PatientDatabaseMenu"));
            AddItem(new MenuAction(4, "Update patient", "PatientDatabaseMenu"));
            AddItem(new MenuAction(5, "Remove patient", "PatientDatabaseMenu"));

            AddItem(new MenuAction(1, "First name", "Update Patient"));
            AddItem(new MenuAction(2, "Last name", "Update Patient"));
            AddItem(new MenuAction(3, "Phone number", "Update Patient"));
            AddItem(new MenuAction(4, "Email address", "Update Patient"));
            AddItem(new MenuAction(5, "Sex", "Update Patient"));
            AddItem(new MenuAction(6, "Age", "Update Patient"));
            AddItem(new MenuAction(7, "Height", "Update Patient"));
            AddItem(new MenuAction(8, "Weight", "Update Patient"));
        }

        public void MenuTitle(string menuName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(menuName.ToUpper());
            Underscore(menuName);
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public ConsoleKeyInfo ReadMenuAction(string menuName, string question)
        {
            Console.WriteLine(question);
            Underscore(question);
            Console.WriteLine();
            var menu = GetMenuActionByMenuName(menuName);

            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{menu[i].Id}. {menu[i].Name}");
            }

            Underscore(question);
            Console.Write("\nYour choose: ");
            var operation = Console.ReadKey();
            Console.WriteLine();
            Underscore(question);

            return operation;
        }

        public void Underscore(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < name.Length; i++)
                Console.Write("-");
            Console.ResetColor();
        }
    }
}
