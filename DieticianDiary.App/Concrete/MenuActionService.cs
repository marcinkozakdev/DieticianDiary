﻿using DieticianDiary.App.Common;
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
            AddItem(new MenuAction(1, "Add patient", "Main"));
            AddItem(new MenuAction(2, "Show patient", "Main"));
            AddItem(new MenuAction(3, "Show all patients", "Main"));
            AddItem(new MenuAction(4, "Update patient", "Main"));
            AddItem(new MenuAction(5, "Remove patient", "Main"));
            AddItem(new MenuAction(0, "Close application", "Main"));
        }
    }
}
