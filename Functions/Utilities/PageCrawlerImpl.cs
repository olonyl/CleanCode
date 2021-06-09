using Functions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Utilities
{
    public enum SuiteReponder
    {
        SUITE_SETUP_NAME,
        SUITE_TEARDOWN_NAME
    }
    public class PageCrawlerImpl
    {
        public static WikiPage GetInheritedPage(SuiteReponder suiteReponder, WikiPage wikiPage)
        {
            return new WikiPage();
        }
        public static WikiPage GetInheritedPage(string setup, WikiPage wikiPage)
        {
            return new WikiPage();
        }
    }
}
