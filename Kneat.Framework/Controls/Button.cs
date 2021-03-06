﻿using Kneat.Common.Controls;
using Kneat.Framework.Core;
using Kneat.Reports;

namespace Kneat.Framework.Controls
{
    public class Button : Control, IButton
    {
        public Button(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
        }

        public Button(WebElement container, Locator locator, string value, string controlName) :
            base(container, locator, value, controlName)
        {
        }

        public void Click()
        {
            Element.Click();

            var message = $"Click on {ControlName}";
            ExtentReportsHelper.Instance.SetStepStatusPass(message);
        }
    }
}
