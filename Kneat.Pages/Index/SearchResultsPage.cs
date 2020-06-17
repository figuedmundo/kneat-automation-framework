using System;
using System.Linq;
using System.Threading;
using Kneat.Common.Controls;
using Kneat.Framework.Controls;
using Kneat.Framework.Core;
using Kneat.Framework.Factories;
using Kneat.Pages.Base;

namespace Kneat.Pages.Index
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage() : base("Search Results")
        {
        }

        public ISelectBox NumberOfAdults => ControlFactory.GetControl<SelectBox>(Locator.Id, "group_adults", "Number Of Adults");
        public ISelectBox NumberOfChildren => ControlFactory.GetControl<SelectBox>(Locator.Id, "group_children", "Number Of Children");
        public ISelectBox NumberOfRooms => ControlFactory.GetControl<SelectBox>(Locator.Id, "no_rooms", "Number Of Rooms");

        public void WaitLoading()
        {
            var loadingBox = ControlFactory.GetControl<Control>(Locator.ClassName, "sr-usp-overlay__loading", "Loading");

            // Wait until Loading box is visible
            if (loadingBox.IsDisplayed())
            {
                // Wait until Loading Box is not present
                var count = 100;
                while (loadingBox.IsPresent() && count > 0)
                {
                    Thread.Sleep(500);
                    count--;
                }
            }

            // log finish waiting

        }

        public void SelectFilterOption(string value)
        {
            var filterControl = ControlFactory.GetControl<Control>(Locator.CssSelector, "#filterbox_options a.filterelement", "Filters");

            var filters = filterControl.Elements;

            var option = filters.SingleOrDefault(f => f.Text.Contains(value, StringComparison.InvariantCultureIgnoreCase));

            if (option != null)
            {
                option.Click();
            }
        }

        public bool IsHotelCardPresent(string hotelName)
        {
            var xpath = $"//div[@id='hotellist_inner']/div[contains(@class,'sr_item') and .//span[contains(@class,'sr-hotel__name') and contains(text(),'{hotelName}')]]";
            var cardControl = ControlFactory.GetControl<Control>(Locator.XPath, xpath, $"'{hotelName}' Hotel Card");

            return cardControl.IsPresent();
        }

        public void VerifyHotelCardIsDisplayed(string hotelName)
        {
            Console.WriteLine(IsHotelCardPresent(hotelName));
        }

        public void VerifyHotelCardIsNotDisplayed(string hotelName)
        {
            Console.WriteLine(IsHotelCardPresent(hotelName));
        }

    }
}
