using Functions.Entities;
using Functions.Utilities;
using System;
using System.Text;

namespace Functions.Wrong
{
    public class HtmlUtil
    {
        public static string TestableHtml(PageData pageData, bool includeSuiteSetup)
        {
            WikiPage wikiPage = pageData.GetWikiPage();
            StringBuilder buffer = new StringBuilder();
            if (pageData.IsTestPage())
            {
                if (includeSuiteSetup)
                {
                    WikiPage suiteSetup = PageCrawlerImpl.GetInheritedPage(SuiteReponder.SUITE_SETUP_NAME, wikiPage);
                    if (suiteSetup != null)
                    {
                        WikiPagePath pagePath = suiteSetup.GetPageCrawler().GetFullPath(suiteSetup);
                        string pagePahtName = PathParser.Render(pagePath);
                        buffer.AppendLine("!include -setup .")
                            .AppendLine(pagePahtName)
                            .AppendLine();
                    }
                }
                WikiPage setup = PageCrawlerImpl.GetInheritedPage("Setup", wikiPage);
                if(setup != null)
                {
                    WikiPagePath setupPath = wikiPage.GetPageCrawler().GetFullPath(setup);
                    string setupPathName = PathParser.Render(setupPath);
                    buffer.AppendLine("!include -setup .")
                        .AppendLine(setupPathName)
                        .AppendLine();
                }
            }
            buffer.AppendLine(pageData.Content);
            if (pageData.IsTestPage ())
            {
                WikiPage teardown = PageCrawlerImpl.GetInheritedPage("TearDown", wikiPage);
                if(teardown != null)
                {
                    WikiPagePath tearDownPath = wikiPage.GetPageCrawler().GetFullPath(teardown);
                    string tearDownPathName = PathParser.Render(tearDownPath);
                    buffer.AppendLine()
                        .AppendLine("!include -setup .")
                        .AppendLine(tearDownPathName)
                        .AppendLine();
                }
                if (includeSuiteSetup)
                {
                    WikiPage suiteTeardown = PageCrawlerImpl.GetInheritedPage(SuiteReponder.SUITE_TEARDOWN_NAME, wikiPage);
                    if(suiteTeardown != null)
                    {
                        WikiPagePath pagePath = suiteTeardown.GetPageCrawler().GetFullPath(suiteTeardown);
                        string pagePathName = PathParser.Render(pagePath);
                        buffer.AppendLine("!include -setup .")
                      .AppendLine(pagePathName)
                      .AppendLine();
                    }
                }
            }
            pageData.Content = buffer.ToString();
            return pageData.Html;
        }
    }
}
