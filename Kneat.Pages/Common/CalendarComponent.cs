using System;
using Kneat.Common.Controls;
using Kneat.Framework.Controls;
using Kneat.Framework.Core;
using Kneat.Framework.Factories;

namespace Kneat.Pages.Common
{
    public class CalendarComponent : Component
    {
        public CalendarComponent()
            : base(Locator.CssSelector, ".bui-calendar", "Calendar")
        {
        }

        public IButton PreviousMonth => ControlFactory
            .GetControl<Button>(this, Locator.CssSelector, "div[data-bui-ref='calendar - prev']", "<");

        public IButton NextMonth => ControlFactory
            .GetControl<Button>(this, Locator.CssSelector, "div[data-bui-ref='calendar-next']", ">");

        public IControl MonthWrapperLeft => ControlFactory
            .GetControl<Control>(this, Locator.CssSelector, ".bui-calendar__wrapper:nth-child(1)", "Month Left");

        public IControl MonthWrapperRight => ControlFactory
            .GetControl<Control>(this, Locator.CssSelector, ".bui-calendar__wrapper:nth-child(2)", "Month Right");
        
        public IControl Display => ControlFactory
            .GetControl<Control>(this, Locator.CssSelector, ".bui-calendar__display", "Calendar Display");


        public void SelectDate(DateTime datetime)
        {
            var formatedDate = datetime.ToString("yyyy-MM-dd");
            var today = DateTime.Now;


            var dateControl = ControlFactory
            .GetControl<Button>(this, Locator.CssSelector, $".bui-calendar__date[data-date='{formatedDate}']", "Month Right");

            var changeMonthButton = datetime > today ? NextMonth : PreviousMonth;
            var monthsDifference = Math.Abs(((today.Year - datetime.Year) * 12) + today.Month - datetime.Month);

            while (!dateControl.IsPresent() && monthsDifference > 0)
            {
                changeMonthButton.Click();
                monthsDifference--;
            }

            dateControl.Highlight();
            dateControl.Click();

        }

    }
}
