using System;
using Kneat.Common.Controls;
using Kneat.Common.Pages;
using Kneat.Framework.Controls;
using Kneat.Framework.Core;
using Kneat.Framework.Factories;
using Kneat.Pages.Base;
using Kneat.Pages.Common;

namespace Kneat.Pages.Index
{
    public class IndexPage : BasePage
    {
        public IndexPage() : base ("Index")
        {
        }

        public ITextBox SearchBox => ControlFactory.GetControl<TextBox>(Locator.CssSelector, "input#ss", "Search Box");

        public IButton CheckIn => ControlFactory.GetControl<Button>(Locator.ClassName, "xp__dates__checkin", "Check In");

        public IButton CheckOut => ControlFactory.GetControl<Button>(Locator.ClassName, "xp__dates__checkout", "Check Out");

        public IButton Search => ControlFactory.GetControl<Button>(Locator.ClassName, "sb-searchbox__button", "Search");

        public CalendarComponent Calendar => ControlFactory.GetControl<CalendarComponent>();

    }
}
