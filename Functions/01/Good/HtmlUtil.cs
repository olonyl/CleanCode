using Functions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Good
{
    public class HtmlUtil:HtmlUtilBase
    {
        public HtmlUtil()
        {

        }
        public string RenderPageWithSetupsAndTearDowns(PageData pageData, bool isSuite) {
            if (pageData.IsTestPage())
            {
                WikiPage testPage = pageData.GetWikiPage();
                StringBuilder newPageContent = new StringBuilder();
                IncludeSetupPages(testPage, newPageContent, isSuite);
                newPageContent.AppendLine(pageData.Content);
                IncludeTeardownPages(testPage, newPageContent, isSuite);
                pageData.Content = newPageContent.ToString();
            }
           
            return pageData.Html;
        }
    }
}
