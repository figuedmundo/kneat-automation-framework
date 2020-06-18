using System;
using Kneat.Common.Behavior;

namespace Kneat.Common.Controls
{
    public interface ISelectBox : IControl, ISelectable
    {
        void VerifyOptionSelected(string expectedValue);
    }
}
