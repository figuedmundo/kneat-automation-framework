using System;
using Kneat.Common.Controls;
using Kneat.Framework.Core;
using Kneat.Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Kneat.Framework.Controls
{
    public class SelectBox : Control, ISelectBox
    {
        private readonly SelectElement SelectWebElement;

        public SelectBox(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
            SelectWebElement = new SelectElement(Element);
        }

        public string GetOptionSelected()
        {
            var option = SelectWebElement.SelectedOption;
            var res = option.Text;

            return res;
        }

        public void SelectByText(string text)
        {
            SelectWebElement.SelectByText(text);
            ExtentReportsHelper.Instance.SetStepStatusPass($"Element {ControlName} has Selected [{text}]");
        }

        public void VerifyOptionSelected(string expectedValue)
        {
            var actual = GetOptionSelected();

            if (actual.Equals(expectedValue, StringComparison.InvariantCultureIgnoreCase))
            {
                ExtentReportsHelper.Instance.SetStepStatusPass($"[{ControlName}] Has the Selected option [{expectedValue}]");
            }
            else
            {
                var message = $"[{ControlName}] Should have the [{expectedValue}] option selected, but it has [{actual}]";
                throw new InvalidElementStateException(message);
            }
        }
    }
}
