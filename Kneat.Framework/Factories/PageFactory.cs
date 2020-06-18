using System;
using Kneat.Reports;

namespace Kneat.Framework.Factories
{
    public class PageFactory
    {

        public static T CreatePage<T>()
        {
            ExtentReportsHelper.Instance.SetStepStatusPass($"<br>Page [{typeof(T).Name}]:<br>");
            return (T)Activator.CreateInstance(typeof(T));
        }

        public static T CreatePage<T>(string title)
        {
            //Log
            ExtentReportsHelper.Instance.SetStepStatusPass($"Page [{title}]:");
            return (T)Activator.CreateInstance(typeof(T), title);
        }
    }
}
