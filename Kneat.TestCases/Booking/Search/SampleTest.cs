using System;
using Kneat.Framework.Factories;
using Kneat.Pages.Index;
using Kneat.TestCases.Base;
using NUnit.Framework;

namespace Kneat.TestCases.Booking.Search
{
    [TestFixture]
    public class SampleTest : BaseTest
    {
        [Test]
        [TestCase("5 stars", "The Savoy Hotel")]
        [TestCase("Sauna", "Limerick Strand Hotel")]
        public void VerifyHotelIsDisplayed(string filterOption, string hotelNamePresent)
        {
            var indexPage = PageFactory.CreatePage<IndexPage>();
            indexPage.SearchBox.SetText("Limerick");
            indexPage.CheckIn.Click();
            indexPage.Calendar.SelectDate(DateTime.Now.AddMonths(3));
            indexPage.Calendar.SelectDate(DateTime.Now.AddMonths(3).AddDays(1));
            indexPage.CheckOut.Click();
            var text = indexPage.Calendar.Display.GetText();
            StringAssert.Contains("(1-night stay)", text);
            indexPage.Search.Click();

            var searchPage = PageFactory.CreatePage<SearchResultsPage>();
            var numberOfAdults = searchPage.NumberOfAdults.GetOptionSelected();
            StringAssert.AreEqualIgnoringCase("2 adults", numberOfAdults);

            searchPage.SelectFilterOption(filterOption);
            searchPage.WaitLoading();
            var res = searchPage.IsHotelCardPresent(hotelNamePresent);

            Assert.IsTrue(res);
        }

        [Test]
        [TestCase("5 stars", "George Limerick Hotel")]
        [TestCase("Sauna", "George Limerick Hotel")]
        public void VerifyHotelIsNotDisplayed(string filterOption, string hotelNamePresent)
        {
            var indexPage = PageFactory.CreatePage<IndexPage>();
            indexPage.SearchBox.SetText("Limerick");
            indexPage.CheckIn.Click();
            indexPage.Calendar.SelectDate(DateTime.Now.AddMonths(3));
            indexPage.Calendar.SelectDate(DateTime.Now.AddMonths(3).AddDays(1));
            indexPage.CheckOut.Click();
            var text = indexPage.Calendar.Display.GetText();
            StringAssert.Contains("(1-night stay)", text);
            indexPage.Search.Click();

            var searchPage = PageFactory.CreatePage<SearchResultsPage>();
            var numberOfAdults = searchPage.NumberOfAdults.GetOptionSelected();
            StringAssert.AreEqualIgnoringCase("2 adults", numberOfAdults);

            searchPage.SelectFilterOption(filterOption);
            searchPage.WaitLoading();
            var res = searchPage.IsHotelCardPresent(hotelNamePresent);

            Assert.IsFalse(res);
        }
    }
}
