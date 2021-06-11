using Functions.Listing3._7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Listing3._7.Entities
{
    public enum SuiteResponder
    {
        SUITE_SETUP_NAME,
        SUITE_TEARDOWN_NAME
    }
    public class PageData : IPageData
    {
        public string Html { get; set; }
        public string Test { get; set; }
        public string Content { get; set; }
        public WikiPage GetWikiPage()
        {
            throw new NotImplementedException();
        }
    }
}
