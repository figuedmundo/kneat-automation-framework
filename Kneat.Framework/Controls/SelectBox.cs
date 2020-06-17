using System;
using Kneat.Common.Controls;
using Kneat.Framework.Core;
using OpenQA.Selenium.Support.UI;

namespace Kneat.Framework.Controls
{
    public class SelectBox : Control, ISelectBox
    {
        private SelectElement SelectWebElement => new SelectElement(Element);

        public SelectBox(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
        }

        public string GetOptionSelected()
        {
            var option = SelectWebElement.SelectedOption;
            return option.Text;
        }

        public void SelectByText(string text)
        {
            SelectWebElement.SelectByText(text);
        }
    }
}
