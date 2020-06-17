using System;
using Kneat.Common.Controls;
using Kneat.Framework.Browser;
using Kneat.Framework.Core;
using OpenQA.Selenium;

namespace Kneat.Framework.Controls
{
    public class Control : WebElement, IControl
    {
        protected WebElement element;


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

            // log

            return text;
        }


        public bool IsDisplayed()
        {
            var res = Element.Displayed;

            // log

            return res;
        }

        public bool IsEnable()
        {
            var res = Element.Enabled;

            // log

            return res;
        }

        public void VerifyText(string expectedValue)
        {
            var text = GetText();


            
            //log

            // validate
        }

        public bool IsPresent()
        {

            try
            {
                return TryFind() != null ;
            }
            catch (Exception)
            {
                return false;
            }

            //log

            // validate
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
                //Log
                
            }
        }
    }
}
