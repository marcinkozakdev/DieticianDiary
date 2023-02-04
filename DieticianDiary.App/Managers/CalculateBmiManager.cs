using DieticianDiary.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieticianDiary.App.Managers
{
    public class CalculateBmiManager
    {
        private readonly MenuActionService _actionService;
        private readonly CalculateBmiService _calculateBmiService;


        public CalculateBmiManager(MenuActionService actionService, CalculateBmiService calculateBmiService)
        {
            _actionService = actionService;
            _calculateBmiService = calculateBmiService;
        }

        public void CalculateBMI()
        {
            _actionService.MenuTitle("Calculate BMI");
            var weight = _calculateBmiService.GetWeight();
            var height = _calculateBmiService.GetHeight();
            var bmi = _calculateBmiService.CalculateBmi(weight, height);
            _calculateBmiService.GetBmiMessage(bmi);
            Console.ReadKey();
        }
    }
}
