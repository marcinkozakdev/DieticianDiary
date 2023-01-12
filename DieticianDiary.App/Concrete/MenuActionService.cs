using DieticianDiary.App.Common;
using DieticianDiary.Domain.Entity;

namespace DieticianDiary.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
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
    }
}
