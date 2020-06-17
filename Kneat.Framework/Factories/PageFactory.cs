using System;
namespace Kneat.Framework.Factories
{
    public class PageFactory
    {

        public static T CreatePage<T>()
        {
            //ManageAttributeValue<T>();

            //Log
            //ResolverLogger.Passed($"<a style>GoTo {typeof(T).Name}.</a>");

            return (T)Activator.CreateInstance(typeof(T));
        }

        public static T CreatePage<T>(string title)
        {
            //ManageAttributeValue<T>();

            //Log
            //ResolverLogger.Passed($"<a style>GoTo {typeof(T).Name}.</a>");

            return (T)Activator.CreateInstance(typeof(T), title);
        }

    }
}
