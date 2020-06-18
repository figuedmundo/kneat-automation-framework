using System;
using System.Linq;
using System.Threading;
using Kneat.Common.Controls;
using Kneat.Framework.Controls;
using Kneat.Framework.Core;
using Kneat.Framework.Factories;
using Kneat.Pages.Base;
using Kneat.Reports;

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
            ExtentReportsHelper.Instance.SetStepStatusPass($"{Title} has Wait Loading.");
        }

        public void SelectFilterOption(string value)
        {
            var filterControl = ControlFactory.GetControl<Control>(Locator.CssSelector, "#filterbox_options a.filterelement", "Filters");

            var filters = filterControl.Elements;

            var option = filters.FirstOrDefault(f => f.Text.Contains(value, StringComparison.InvariantCultureIgnoreCase));

            if (option != null)
            {
                option.Click();
                ExtentReportsHelper.Instance.SetStepStatusPass($"{Title} has Select Filter [{value}]");
            }
            else
            {
                throw new Exception($"{Title} doesn't have the Filter option [{value}]");
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

            if (IsHotelCardPresent(hotelName))
            {
                ExtentReportsHelper.Instance.SetStepStatusPass($"{Title} page has the [{hotelName}] Hotel Card Displayed.");
            }
            else
            {
                throw new Exception($"{Title} page should have the [{hotelName}] Hotel Card Displayed.");
            }
        }

        public void VerifyHotelCardIsNotDisplayed(string hotelName)
        {

            if (!IsHotelCardPresent(hotelName))
            {
                ExtentReportsHelper.Instance.SetStepStatusPass($"{Title} page has not the [{hotelName}] Hotel Card Displayed.");
            }
            else
            {
                throw new Exception($"{Title} page should have not the [{hotelName}] Hotel Card Displayed.");
            }
        }
    }
}
