using System;
using Kneat.Common.Controls;
using Kneat.Framework.Browser;
using Kneat.Framework.Core;
using Kneat.Reports;
using OpenQA.Selenium;

namespace Kneat.Framework.Controls
{
    public class Control : WebElement, IControl
    {
        public Control(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {
        }

        public Control(WebElement container, Locator locator, string value, string controlName) :
            base(container, locator, value, controlName)
        {
        }

        public string GetText()
        {
            var text = Element.Text;

            var message = $"Get Text from {ControlName}, text: [{text}]";
            ExtentReportsHelper.Instance.SetStepStatusPass(message);

            return text;
        }

        public bool IsDisplayed()
        {
            var res = Element.Displayed;

            var message = $"Element {ControlName} is Displayed";
            ExtentReportsHelper.Instance.SetStepStatusPass(message);

            return res;
        }

        public bool IsEnable()
        {
            var res = Element.Enabled;

            var message = $"Element {ControlName} is Enable";
            ExtentReportsHelper.Instance.SetStepStatusPass(message);

            return res;
        }

        public bool IsPresent()
        {
            try
            {
                return TryFind() != null ;
            }
            catch (Exception ex)
            {
                ExtentReportsHelper.Instance.SetStepStatusInformation($"Element {ControlName} is not Present, Exception [{ex.Message}]");
                return false;
            }
        }

        public void Highlight()
        {
            try
            {
                var jsDriver = (IJavaScriptExecutor)BrowserManager.Instance.Driver;
                const string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: blue"";";
                var originalElementBorder = (string)jsDriver.ExecuteScript(highlightJavascript, Element);
            }
            catch (Exception ex)
            {
                ExtentReportsHelper.Instance.SetStepStatusInformation($"Element {ControlName} cannot " +
                    $"be Hihglighted, Exception [{ex.Message}]");
            }
        }

        public void VerifyContainsText(string expectedValue)
        {
            var text = GetText();

            if (text.Contains(expectedValue, StringComparison.InvariantCultureIgnoreCase))
            {
                ExtentReportsHelper.Instance.SetStepStatusPass($"[{ControlName}]: Verified Text Contains [{expectedValue}]");
            }
            else
            {
                var message = $"[{ControlName}]: Failed, Text [{text}], expected to contains [{expectedValue}]";
                throw new InvalidElementStateException(message);
            }
        }
    }
}
