using System;
using Kneat.Common.Controls;
using Kneat.Common.Pages;
using Kneat.Framework.Controls;
using Kneat.Framework.Core;

namespace Kneat.Pages.Base
{
    public class BaseComponent : Component
    {
        public BaseComponent(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
        }

    }
}
