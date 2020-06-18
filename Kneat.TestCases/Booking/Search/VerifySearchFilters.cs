using System;
using Kneat.Pages.Base;
using Kneat.TestCases.Base;
using NUnit.Framework;

namespace Kneat.TestCases.Booking.Search
{
    [TestFixture]
    public class VerifySearchFilters : BaseTest
    {
        [Test]
        [TestCase("5 stars", "The Savoy Hotel")]
        [TestCase("Sauna", "Limerick Strand Hotel")]
        public void VerifyHotelIsDisplayed(string filterOption, string hotelNamePresent)
        {
            var indexPage = Page.Index;
            indexPage.SearchBox.SetText("Limerick");
            indexPage.CheckIn.Click();
            indexPage.Calendar.SelectDate(DateTime.Now.AddMonths(3));
            indexPage.Calendar.SelectDate(DateTime.Now.AddMonths(3).AddDays(1));
            indexPage.CheckOut.Click();
            indexPage.Calendar.Display.VerifyContainsText("(1-night stay)");
            indexPage.Search.Click();

            var searchPage = Page.SearchResults;
            searchPage.NumberOfAdults.VerifyOptionSelected("2 adults");
            searchPage.NumberOfChildren.VerifyOptionSelected("No children");
            searchPage.NumberOfRooms.VerifyOptionSelected("1 room");
            searchPage.SelectFilterOption(filterOption);
            searchPage.WaitLoading();
            searchPage.VerifyHotelCardIsDisplayed(hotelNamePresent);
        }

        [Test]
        [TestCase("5 stars", "George Limerick Hotel")]
        [TestCase("Sauna", "George Limerick Hotel")]
        public void VerifyHotelIsNotDisplayed(string filterOption, string hotelNamePresent)
        {
            var indexPage = Page.Index;
            indexPage.SearchBox.SetText("Limerick");
            indexPage.CheckIn.Click();
            indexPage.Calendar.SelectDate(DateTime.Now.AddMonths(3));
            indexPage.Calendar.SelectDate(DateTime.Now.AddMonths(3).AddDays(1));
            indexPage.CheckOut.Click();
            indexPage.Calendar.Display.VerifyContainsText("(1-night stay)");
            indexPage.Search.Click();

            var searchPage = Page.SearchResults;
            searchPage.NumberOfAdults.VerifyOptionSelected("2 adults");
            searchPage.NumberOfChildren.VerifyOptionSelected("No children");
            searchPage.NumberOfRooms.VerifyOptionSelected("1 room");
            searchPage.SelectFilterOption(filterOption);
            searchPage.WaitLoading();
            searchPage.VerifyHotelCardIsNotDisplayed(hotelNamePresent);
        }
    }
}
