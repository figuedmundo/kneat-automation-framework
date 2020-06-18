using System;
using Kneat.Framework.Factories;
using Kneat.Pages.Index;

namespace Kneat.Pages.Base
{
    public class Page
    {
        public static IndexPage Index => PageFactory.CreatePage<IndexPage>();

        public static SearchResultsPage SearchResults => PageFactory.CreatePage<SearchResultsPage>();
    }
}
