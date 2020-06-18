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

        public void AcceptCookies()
        {
            var acceptButton = ControlFactory.GetControl<Button>(Framework.Core.Locator.CssSelector,
            "#cookie_warning button[data-gdpr-consent='accept']", "Accept Cookies");

            if (acceptButton.IsPresent())
            {
                acceptButton.Click();
            }
        }

        // Header

        // Footer
    }
}
