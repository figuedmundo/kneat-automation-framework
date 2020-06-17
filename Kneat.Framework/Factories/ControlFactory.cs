using System;
using Kneat.Common.Controls;
using Kneat.Framework.Core;

namespace Kneat.Framework.Factories
{
    public class ControlFactory
    {
        public static T GetControl<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public static T GetControl<T>(Locator locator, string value, string controlName)
        {
            return (T)Activator.CreateInstance(typeof(T), locator, value, controlName);
        }

        public static T GetControl<T>(WebElement container, Locator locator, string value, string controlName)
        {
            return (T)Activator.CreateInstance(typeof(T), container, locator, value, controlName);
        }
    }
}
