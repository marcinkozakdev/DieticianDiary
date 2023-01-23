using DieticianDiary.App.Concrete;

namespace DieticianDiary.App.Managers
{
    public class UserDataManager
    {
        private readonly UserDataService _userDataService;
        private readonly MenuActionService _actionService;


        public UserDataManager(UserDataService userDataService, MenuActionService actionService)
        {
            _userDataService = userDataService;
            _actionService = actionService;
        }

        public void GoToUserData(MenuActionService actionService)
        {
            while (true)
            {
                actionService.MenuTitle("User Data Menu");

                if (_userDataService.userData.FirstName is null || _userDataService.userData.LastName is null || _userDataService.userData.EmailAddress is null)
                    _userDataService.InputUserData();

                else
                {
                    _userDataService.ShowUserData();

                    var operation = _actionService.ReadMenuAction("User Data Menu", "\nPlease let me know what you want to do:");

                    if (operation.KeyChar != '1')
                        return;
                    
                    _userDataService.UpdateUserData();
                }
            }
        }
    }
}
