using Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Good
{
    public class HtmlUtilBase
    {
        private StringBuilder _content = new StringBuilder();
        public void IncludeSetupPages(IWikiPage wikiPage, StringBuilder newPageContent, bool isSuite) 
        {
            _content.Append(newPageContent);
        }
        public void IncludeTeardownPages(IWikiPage wikiPage, StringBuilder newPageContent, bool isSuite) 
        {
            _content.Append(newPageContent);
        }
    }
}
