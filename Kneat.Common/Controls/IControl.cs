using System;
namespace Kneat.Common.Controls
{
    public interface IControl
    {
        bool IsDisplayed();
        bool IsEnable();
        void VerifyText(string expectedValue);
        string GetText();
        void Highlight();
        bool IsPresent();
    }
}
