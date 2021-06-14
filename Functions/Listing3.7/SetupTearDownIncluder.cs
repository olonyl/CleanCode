using Functions.Listing3._7.Entities;
using Functions.Listing3._7.Interfaces;
using Functions.Listing3._7.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Listing3._7
{
    public class SetupTearDownIncluder : ISetupTearDownIncluder
    {
        private PageData pageData;
        private bool isSuite;
        private WikiPage testPage;
        private StringBuilder newPageContent;
        private PageCrawler pageCrawler;
        public SetupTearDownIncluder(PageData pageData)
        {
            this.pageData = pageData;
            testPage = pageData.GetWikiPage();
            pageCrawler = testPage.GetPageCrawler();
            newPageContent = new StringBuilder();
        }
        public string Render(PageData pageData)
        {
            return Render(pageData, false);
        }

        public string Render(PageData pageData, bool isSuite)
        {
            return new SetupTearDownIncluder(pageData).Render(isSuite);
        }

        public string Render(bool isSuite)
        {
            this.isSuite = isSuite;
            if (IsTestPage())
                IncludeSetupPages();
            return pageData.Html;
        }

        public bool IsTestPage()
        {
            return pageData.Test != null; 
        }
        public void IncludeSetupAndTeardownPages()
        {
            IncludeSetupPage();
            IncludeSetupContent();
            IncludeTeardownPages();
            UpdatePageContent();
        }
        public void IncludeSetupPages()
        {
            if (isSuite)
                IncludeSuiteSetupPage();
            IncludeSetupPage();
        }
        public void IncludeSuiteSetupPage()
        {
            Include(SuiteResponder.SUITE_SETUP_NAME, "-setup");
        }
        public void IncludeSetupPage()
        {
            Include("SetUp","-setup");
        }       
        public void IncludePageContent()
        {
            newPageContent.AppendLine(pageData.Content);
        }
        public void IncludeTeardownPage()
        {
            Include("TearDown", "-teardown");
        }
        public void IncludeSuiteTeardownPage()
        {
            Include(SuiteResponder.SUITE_TEARDOWN_NAME, "-teardown");
        }
        public void UpdatePageContent()
        {
            pageData.Content = newPageContent.ToString();
        }
        public void Include(string pageName, string arg)
        {
            WikiPage inheritedPage = FindInheritedPage(pageName);
            if(inheritedPage!= null)
            {
                string pagePathName = GetPahtNameForPage(inheritedPage);
                BuildIncludeDirective(pagePathName, arg);
            }
        }
        public WikiPage FindInheritedPage(string pageName)
        {
            return PageCrawlerImpl.GetInheritedPage(pageName,testPage);
        }
        public string GetPahtNameForPage(WikiPage page)
        {
            WikiPagePath pagePath = pageCrawler.GetFullPath(page);
            return PathParser.Render(pagePath);
        }
        public void BuildIncludeDirective(string pagePathName, string arg)
        {
           newPageContent
                .AppendLine("\n!include ")
                .AppendLine(arg)
                 .AppendLine(" .")
                 .AppendLine(pagePathName)
                 .AppendLine();
        }

        void IncludeSetupContent()
        {

        }
        public void Include(SuiteResponder pageName, string arg)
        {
            throw new NotImplementedException();
        }
        public void IncludeTeardownPages()
        {
            throw new NotImplementedException();
        }
    }
}
