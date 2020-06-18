using Kneat.Common.Controls;
using Kneat.Common.Pages;
using Kneat.Framework.Controls;
using Kneat.Framework.Factories;

namespace Kneat.Pages.Base
{
    public class BasePage : IPage
    {
        public string Title { get; set; }

        public BasePage(string title)
        {
            Title = title;
            AcceptCookies();
        }

        public IButton AcceptButton => ControlFactory.GetControl<Button>(Framework.Core.Locator.CssSelector,
            "#cookie_warning button[data-gdpr-consent='accept']", "Accept Cookies");

        public void AcceptCookies()
        {
            if (AcceptButton.IsPresent())
            {
                AcceptButton.Click();
            }
        }

        // Header

        // Nav bar
    }
}
