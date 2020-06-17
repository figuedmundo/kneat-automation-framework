using System;
using Kneat.Common.Behavior;
using Kneat.Common.Controls;
using Kneat.Framework.Core;

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
            throw new NotImplementedException();
        }

        public void SetText(string text)
        {
            Element.SendKeys(text);

            // log
        }
    }
}
