using Kneat.Framework.Core;

namespace Kneat.Framework.Controls
{
    public class Component : Control
    {
        public Component(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
        }
    }
}
