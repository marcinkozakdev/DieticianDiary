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
            foreach (var menuAction in Patients)
            {
                if (menuAction.MenuName == menuName)
                    result.Add(menuAction);
            }
            return result;
        }

        private void Initialize()
        {
            AddPatient(new MenuAction(1, "Add patient", "Main"));
            RemovePatient(new MenuAction(2, "Remove patient", "Main"));
            GetPatient(new MenuAction(3, "Show patient", "Main"));
            GetAllPatients(new MenuAction(4, "List of patients", "Main"));
            UpdatePatient(new MenuAction(5, "Update patient", "Main"));
        }
    }
}
