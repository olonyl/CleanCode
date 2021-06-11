using Functions.Listing3._7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Listing3._7.Interfaces
{
    public interface ISetupTearDownIncluder
    {
        string Render(PageData pageData);
        string Render(PageData pageData, bool isSuite);
        string Render(bool isSuite);
        bool IsTestPage();
        void IncludeSetupAndTeardownPages();
        void IncludeSetupPages();
        void IncludeSuiteSetupPage();
        void IncludeSetupPage();
        void IncludePageContent();
        void IncludeTeardownPages();
        void IncludeTeardownPage();
        void IncludeSuiteTeardownPage();
        void UpdatePageContent();
        void Include(SuiteResponder pageName, string arg);
        void Include(string pageName, string arg);
        WikiPage FindInheritedPage(string pageName);
        string GetPahtNameForPage(WikiPage page);
        void BuildIncludeDirective(string pagePathName, string arg);
    }
}
