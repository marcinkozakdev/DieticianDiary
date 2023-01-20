using DieticianDiary.App.Common;
using DieticianDiary.Domain.Entity;

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
            AddItem(new MenuAction(1, "User data", "Main"));
            AddItem(new MenuAction(2, "Patient database", "Main"));
            AddItem(new MenuAction(3, "BMI calculator", "Main"));
            AddItem(new MenuAction(0, "Close application", "Main"));

            AddItem(new MenuAction(0, "Back to main menu", "UserDataMenu"));
            AddItem(new MenuAction(1, "Update data", "UserDataMenu"));

            AddItem(new MenuAction(1, "Add patient", "Patient database"));
            AddItem(new MenuAction(2, "Show patient", "Patient database"));
            AddItem(new MenuAction(3, "Show all patients", "Patient database"));
            AddItem(new MenuAction(4, "Update patient", "Patient database"));
            AddItem(new MenuAction(5, "Remove patient", "Patient database"));
            AddItem(new MenuAction(0, "Close application", "Patient database"));

            AddItem(new MenuAction(1, "First name", "Update Patient"));
            AddItem(new MenuAction(2, "Last name", "Update Patient"));
            AddItem(new MenuAction(3, "Phone number", "Update Patient"));
            AddItem(new MenuAction(4, "Email address", "Update Patient"));
            AddItem(new MenuAction(5, "Sex", "Update Patient"));
            AddItem(new MenuAction(0, "Age", "Update Patient"));
            AddItem(new MenuAction(0, "Height", "Update Patient"));
            AddItem(new MenuAction(0, "Weight", "Update Patient"));
        }
    }
}
