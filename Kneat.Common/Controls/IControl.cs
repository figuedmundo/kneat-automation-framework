using System;
namespace Kneat.Common.Controls
{
    public interface IControl
    {
        bool IsDisplayed();
        bool IsEnable();
        string GetText();
        void Highlight();
        bool IsPresent();
        void VerifyContainsText(string expectedValue);

    }
}
