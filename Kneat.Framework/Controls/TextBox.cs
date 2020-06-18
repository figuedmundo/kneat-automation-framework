using Kneat.Common.Controls;
using Kneat.Framework.Core;
using Kneat.Reports;

namespace Kneat.Framework.Controls
{
    public class TextBox : Control, ITextBox
    {
        public TextBox(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
        }

        public TextBox(WebElement container, Locator locator, string value, string controlName) :
            base(container, locator, value, controlName)
        {
        }

        public void Clear()
        {
            Element.Clear();

            // log
            ExtentReportsHelper.Instance.SetStepStatusPass($"Element {ControlName} cleared");
        }

        public void SetText(string text)
        {
            Element.SendKeys(text);

            // log
            ExtentReportsHelper.Instance.SetStepStatusPass($"Element {ControlName} has Set Text [{text}]");
        }
    }
}
