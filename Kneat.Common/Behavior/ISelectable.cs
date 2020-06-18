using System;
namespace Kneat.Common.Behavior
{
    public interface ISelectable
    {
        void SelectByText(string text);

        string GetOptionSelected();
    }
}
